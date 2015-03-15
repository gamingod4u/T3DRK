using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour 
{
	private Car_Motor carMotor;
	private int motorLevel;
	private int accelerationLevel;
	private int fueltankLevel;
	private int fuelConsumptionLevel;
	private int steeringLevel;
	private int boostLevel;
	
	
	#region Getter/Setter Functions
	public int Motor
	{
		get{return motorLevel;}
		set{motorLevel = value;}
	}
	public int Acceleration
	{
		get{return accelerationLevel;}
		set{accelerationLevel = value;}
	}	
	public int FuelTank
	{
		get{return fueltankLevel;}
		set{fueltankLevel = value;}
	}
	public int ConsumptionLevel
	{
		get{return fuelConsumptionLevel;}
		set{fuelConsumptionLevel = value;}
	}
	public int SteeringSensitivity
	{
		get{return steeringLevel;}
		set{steeringLevel = value;}
	}
	public int Boost
	{
		get{return boostLevel;}
		set{boostLevel = value;}
	}
	#endregion
	
	void Start()
	{
		carMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<Car_Motor>();
		SwitchComponents();
	}
	void Update()
	{
		SwitchComponents();
	// Update is called once per frame
	}
	
	void SwitchComponents()
	{
		SwitchMaxSpeed();
		SwitchAcceleration();
		SwitchFuelTank();
		SwitchFuelDuration();
		SwitchSteering();
		SwitchBoost();
	}
	
	private void SwitchMaxSpeed()
	{
		switch(motorLevel)
		{
			case 1: carMotor.MaxSpeed = 25;break; carMotor.startPitch = 1;
			case 2: carMotor.MaxSpeed = 30;break; carMotor.startPitch = .5f;
			case 3: carMotor.MaxSpeed = 35;break; carMotor.startPitch = 0;
			case 4: carMotor.MaxSpeed = 40;break; carMotor.startPitch = -1;
			case 5: carMotor.MaxSpeed = 50;break; carMotor.startPitch = -2;
		}
	}
	
	private void SwitchAcceleration()
	{
		switch(accelerationLevel)
		{
			case 1: carMotor.Acceleration = 15;break;
			case 2: carMotor.Acceleration = 18;break;
			case 3: carMotor.Acceleration = 20;break;
			case 4: carMotor.Acceleration = 22;break;
			case 5: carMotor.Acceleration = 25;break;
		}	
	}
	
	private void SwitchFuelTank()
	{
		switch(fueltankLevel)
		{
		case 1: carMotor.FuelGauge = 50;break;
		case 2: carMotor.FuelGauge = 60;break;
		case 3: carMotor.FuelGauge = 75;break;
		case 4: carMotor.FuelGauge = 85;break;
		case 5: carMotor.FuelGauge = 100;break;
		}	
	}
	private void SwitchFuelDuration()
	{
	
	}
	private void SwitchSteering()
	{
		switch(steeringLevel)
		{
			case 1: carMotor.SteeringSensitivity = .60f;break;
			case 2: carMotor.SteeringSensitivity = .70f;break;
			case 3: carMotor.SteeringSensitivity = .80f;break;
			case 4: carMotor.SteeringSensitivity = .90f;break;
			case 5: carMotor.SteeringSensitivity = 1f;break;
		}	
	}
	private void SwitchBoost()
	{
		switch(boostLevel)
		{
			case 1: carMotor.BoostPower = 10f;carMotor.BoostTimer = 3f;break;
			case 2: carMotor.BoostPower = 20f;carMotor.BoostTimer = 3f;break;
			case 3: carMotor.BoostPower = 30f;carMotor.BoostTimer = 3f;break;
			case 4: carMotor.BoostPower = 40f;carMotor.BoostTimer = 3f;break;
			case 5: carMotor.BoostPower = 50f;carMotor.BoostTimer = 3f;break;
		}	
	}
}
