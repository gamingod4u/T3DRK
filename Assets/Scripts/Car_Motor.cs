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
	}
	
	
	// Update is called once per frame
	void Update () 
	{
		GetSteering();
		GetMotor();
		MoveCar();
		SteerCar();
		
		CheckGrounded();
		ClipRotation();
	}
	
	private void ClipRotation()
	{
		if(!isGrounded)
		{
			if(car.transform.rotation.x > 15f)
			 	car.transform.Rotate(-Time.deltaTime,0,0);
			else if(car.transform.rotation.x < -15f)
				car.transform.Rotate(Time.deltaTime,0,0);
			else
				car.transform.rotation = new Quaternion(0, car.transform.rotation.y, car.transform.rotation.z, car.transform.rotation.w);
				
				
				car.transform.Translate(Vector3.down * car_Rigid.mass  *Time.deltaTime);
			
		}
	}
	private void CheckGrounded()
	{
		
	}
	private void GetSteering()
	{
		
		if(Input.acceleration.x > 0.05f)
		{
			if(steeringWheel < 1f)		
				steeringWheel += .05f;
		}
		else if(Input.acceleration.x < -0.05f)
		{
			if(steeringWheel > -1f)
				steeringWheel -= .05f;
		}
		else
		{
			if(steeringWheel > 0.5f)
				steeringWheel -= .15f;
			else if(steeringWheel < 0.5f)
				steeringWheel += .15f;
			else 
				steeringWheel = 0f;
		}
		
	}
	
	private void GetMotor()
	{
		if(brakePedal > 0f)
		{
			if(gasPedal > -1f)
				gasPedal -= .2f;
			else
				gasPedal = -2f;
		}
		else
		{
			if(gasPedal < 1f)
				gasPedal += .015f;
			else
			{
				gasPedal = 1f;
			}
			
			if(currentSpeed < maxSpeed)
				currentSpeed += (gasPedal * acceleration) * Time.deltaTime;
			else
			{
				if(!isBoosting)
					currentSpeed -= (gasPedal * acceleration) * Time.deltaTime;
			}
		}
	}
	
	private void MoveCar()
	{
			if(currentSpeed != 0)
				car.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
				
	}
	
	
	private void SteerCar()
	{
		car.Rotate(0,steeringWheel * (currentSpeed*steeringSensitivy),0);
		
			 
	}
	
	public void BrakeButton()
	{
		
	}
	
}
