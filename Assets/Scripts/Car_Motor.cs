using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Car_Motor : MonoBehaviour
{
	
	public static Car_Motor instance;
	
	public Transform car;
	public Transform car_body;
	public Rigidbody car_Rigid;
	
	public int maxSpeed = 0;
	public bool  isGrounded = true;
	public bool  isBoosting = false;
	public float gasPedal = 0;
	public float brakePedal = 0;
	public float steeringWheel = 0;
	public float fuelGauge = 0;
	public float acceleration = 0;
	public float steeringSensitivy = 0;
	public float currentSpeed = 0;
	
	private float downForce = 0;
	
	#region Getter/Setters
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
	
	public float Acceleration
	{
		get{return acceleration;}
		set{acceleration = value;}
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
	
	public float CurrentSpeed
	{
		get{return currentSpeed;}
		set{currentSpeed = value;}
	}
	public int MaxSpeed
	{
		get{return maxSpeed;}
		set{maxSpeed = value;}
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
		car_Rigid.centerOfMass = new Vector3(0, 0 ,1f);
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GetMotor();
		MoveCar();
		SteerCar();
		ClipRotation();
	}
	
	private void ClipRotation()
	{
		if(!isGrounded)
		{	
			if(currentSpeed > 0)
			currentSpeed -= acceleration * (Time.deltaTime * Time.deltaTime);
			else
				currentSpeed = 0;
			
			car.Translate( Vector3.down * car_Rigid.mass * (Time.deltaTime * Time.deltaTime));
			car.transform.eulerAngles = new Vector3(car.transform.eulerAngles.x, car.transform.eulerAngles.y, 0);
		}
		else 
		{
			downForce = 0;
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
			if(gasPedal < 1f)
				gasPedal += .15f;
			else
				gasPedal = 1f;
		}
		
		if(currentSpeed < maxSpeed && isGrounded)
			currentSpeed += (gasPedal * acceleration) * Time.deltaTime;
		else
		{
			if(!isBoosting)
				currentSpeed -= (acceleration) * Time.deltaTime;
		}
	}
	
	private void MoveCar()
	{
			if(currentSpeed != 0)
				car.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
				
	}
	
	
	private void SteerCar()
	{
		if(currentSpeed != 0)
		{
			car.Rotate(0,steeringWheel * (steeringSensitivy),0);
		}

		if(steeringWheel >  .7f)  // if we are driftable right
		{

		}
		else if(steeringWheel < - .7f) // if we are driftable left
		{

		}
		else // if we are not trying to drift lets see if car is 
		{
			if(car_body.rotation.y > .1f) // if car is drifting right 
			{

			}
			else if(car_body.rotation.y < -.1f) // if car is drifting left 
			{

			}
			else // make sure the car is straigth
			{

			}
		}
			 
	}
	
	public void BrakeButton()
	{
		
	}
	
}
