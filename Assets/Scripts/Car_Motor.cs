using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class Car_Motor : MonoBehaviour
{
	
	public static Car_Motor instance;
	
	public Transform car;
	public Transform car_body;
	public Rigidbody car_Rigid;
	public Text 	 carSpeedText;
	public Text      fuelText;
	
	public int 		maxSpeed = 0;
	public bool  	isGrounded = true;
	public bool  	isBoosting = false;
	public float 	gasPedal = 0;
	public float 	brakePedal = 0;
	public float 	steeringWheel = 0;
	public float 	boostPower = 0;
	public float 	fuelConsumption = 0;
	public float	fuelGauge = 0;
	public float	acceleration = 0;
	public float 	steeringSensitivy = 0;
	public float    boostTime = 0;
	public float 	boostTimer = 0;
	public float    fuelTimer = 0;
	public float 	fuelTime = 0;
	public float 	currentSpeed = 0;
	
	private float downForce = 0;
	private AudioSource audioPlayer;
	public float 		startPitch = 0;

	
	#region Getter/Setters
	#region Bools
	public bool Ground
	{
		get{return isGrounded;}
		set{isGrounded = value;}
	}
	
	public bool Boost
	{
		get{return isBoosting;}
		set{isBoosting = value;}
	}
	#endregion
	#region Input Controls
	public float GasPedal
	{
		get{return gasPedal;}
		set{gasPedal = value;}
	}	
	
	public float BrakePedal
	{
		get{return brakePedal;}
		set{brakePedal = value;}
	}	
	
	public float SteeringWheel
	{
		get{return steeringWheel;}
		set{steeringWheel = value;}
	}	
	
	#endregion
	#region Customizable Variables
	public int MaxSpeed
	{
		get{return maxSpeed;}
		set{maxSpeed = value;}
	}
	public float Acceleration
	{
		get{return acceleration;}
		set{acceleration = value;}
	}
	
	public float FuelDuration
	{
		get{return fuelConsumption;}
		set{fuelConsumption = value;}
	}
		
	public float FuelGauge
	{
		get{return fuelGauge;}
		set{fuelGauge = value;}
	}
	
	public float SteeringSensitivity
	{
		get{return steeringSensitivy;}
		set{steeringSensitivy = value;}
	}
	
	public float BoostPower
	{
		get{return boostPower;}
		set{boostPower = value;}
	}
	
	public float BoostTimer
	{
		get{return boostTimer;}
		set{boostTimer = value;}
	}
	#endregion
	public float CurrentSpeed
	{
		get{return currentSpeed;}
		set{currentSpeed = value;}
	}
	#endregion
	void Awake()
	{
		if(instance != null)
			Destroy(this.gameObject);
			
		instance = this;
	}
	
	void Start()
	{
		car_Rigid = gameObject.GetComponent<Rigidbody>();
		
		audioPlayer = gameObject.GetComponent<AudioSource>();
		//car_Rigid.centerOfMass = new Vector3(0, 0 ,1);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GetMotor();
		MoveCar();
		SteerCar();
		CheckGrounded();
	}
	
	private void CheckGrounded()
	{
		if(!isGrounded)
		{
			StartCoroutine("RotateX");
			car.localEulerAngles = new Vector3(car.localEulerAngles.x, car.localEulerAngles.y, 0);
			car_Rigid.mass += 20 ; // this will be multiplied by the level of the motor. to add weight to the car
		}
		else 
		{
			car_Rigid.mass = 250;
		}	
	}
	
	private void GetMotor()
	{
		if(brakePedal > 0f)
		{
			if(gasPedal > -1f)
				gasPedal -= .1f;
			else
				gasPedal = -1f;
		}
		else
		{
			if(!isGrounded)
				gasPedal = 0;
			else
				if(gasPedal < 1f)
					gasPedal += .15f;
				else
					gasPedal = 1f;
		}
		
		
		if(currentSpeed < maxSpeed && !isBoosting)
				currentSpeed += (gasPedal * acceleration) * Time.deltaTime;
	    else if(isBoosting && currentSpeed < maxSpeed + boostPower)
				currentSpeed += (gasPedal * 35f) * Time.deltaTime;
		else
		{
			if(!isBoosting)
				currentSpeed -= (acceleration) * Time.deltaTime;
		}
		
		///AUDIO PLAYER SETTINGS FOR NOW BUST TO A NEW CLASS LATER ////
		if(currentSpeed != 0)
		{
			float thisPitch = currentSpeed*maxSpeed/1000;
			thisPitch += startPitch;
			audioPlayer.pitch = thisPitch;
			
		}
		
		if(isBoosting && boostTime < boostTimer)
			boostTime += Time.deltaTime;
		else
		{
			boostTime = 0;
			isBoosting = false;
		}
		
		carSpeedText.text  = "Speed: " + (int)currentSpeed + "MPH "; // can move later just for testing. 			
	}
	private void CheckFuel()
	{
		if(fuelTimer < 3)
		{
			fuelTimer += Time.deltaTime;
			fuelGauge -= 3/fuelConsumption;	
		}
		else
		{
			fuelTimer = 0;
		}
		fuelText.text = "Batt Life: " + (int)fuelGauge + "gal";  // can move later in just for testing.
	}
	
	private void MoveCar()
	{
			if(currentSpeed != 0 && fuelGauge > 0)
			{
				car.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
				CheckFuel();
			}			
	}
	
	
	private void SteerCar()
	{
		if(currentSpeed != 0 && isGrounded)
		{
			car.Rotate(0,steeringWheel * steeringSensitivy,0);
		}

		if(steeringWheel > .8f && currentSpeed > maxSpeed*.5f)  // if we are driftable right
		{
			if(car_body.localRotation.y < .25f)
				car_body.Rotate(0, steeringWheel * .25f,0);
				
		}
		else if(steeringWheel < -.8f && currentSpeed > maxSpeed*.5f) // if we are driftable left
		{
			if(car_body.localRotation.y > -.25)
				car_body.Rotate(0, steeringWheel * .25f,0);
		}
		else // if we are not trying to drift lets see if car is 
		{
			if(car_body.localRotation.y > .01f) // if car is drifting right 
			{
				car_body.Rotate(0, -1f ,0);
			}
			else if(car_body.localRotation.y < -.01f) // if car is drifting left 
			{
				car_body.Rotate(0, 1f,0);
			}
			else // make sure the car is straigth
			{
				car_body.localEulerAngles = new Vector3(0,0,0);
			}
		}
			 
	}
	
	private IEnumerator RotateX()
	{
		while(!isGrounded)
		{
			if(car.localEulerAngles.x > 8)
				car.localEulerAngles = new Vector3(car.localEulerAngles.x + Time.deltaTime, car.localEulerAngles.y, 0);
			else if (car.localEulerAngles.x < -8)
				car.localEulerAngles = new Vector3(car.localEulerAngles.x + Time.deltaTime, car.localEulerAngles.y, 0);
		
				yield return null;
		}
	
		yield return null;
	}
}
