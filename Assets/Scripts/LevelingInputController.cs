﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelingInputController : MonoBehaviour 
{
	#region Class Variables
	public enum SteeringType{tilt, touch}
	public Text motorText;
	public Text accelText;
	public Text batteryText;
	public Text wearText; 
	public Text boostText;
	public Text steeringText;
	public LevelController levelController;
	
	private int motorLevel = 1;
	private int accelLevel= 1;
	private int batteryLevel= 1;
	private int wearLevel= 1;
	private int boostLevel= 1;
	private int steeringLevel= 1;
	#endregion
	#region Button Functions
	public void MotorUp()
	{
		motorLevel++;
		Motor();
	}
	public void MotorDown()
	{
		motorLevel--;
		Motor();
	}
	public void AceelerationUp()
	{
		accelLevel++;
		Acceleration();
	}
	public void AccelerationDown()
	{
		accelLevel--;
		Acceleration();
	}
	public void BatteryUp()
	{
		batteryLevel++;
		BatterLevels();
	}
	public void BatteryDown()
	{
		batteryLevel--;
		BatterLevels();
	}
	public void UsageUp()
	{
		wearLevel++;
		ConsumptionLevels();
	}
	public void UsageDown()
	{
		wearLevel--;
		ConsumptionLevels();
	}
	public void BoostUp()
	{
		boostLevel++;
		BoostLevels();
	}
	public void BoostDown()
	{
		boostLevel--;
		BoostLevels();
	}
	public void SteeringUp()
	{
		steeringLevel++;
		SteeringLevels();
	}
	public void SteeringDown()
	{
		steeringLevel--;
		SteeringLevels();
	}
	#endregion
	
	
	#region Unity Functions
	void Start()
	{
		Motor();
		Acceleration();
		BatterLevels();
		ConsumptionLevels();
		BoostLevels();
		SteeringLevels();
	}
	void Update()
	{
		
	}
	#endregion
	#region Class Functions
	private void Motor()
	{
		motorLevel = Mathf.Clamp(motorLevel,1,5);
		switch(motorLevel)
		{
			case 1: motorText.text = "Lvl 1 25 MPH";break;
			case 2: motorText.text = "Lvl 2 30 MPH";break;
			case 3: motorText.text = "Lvl 3 35 MPH";break;
			case 4: motorText.text = "Lvl 4 40 MPH";break;
			case 5: motorText.text = "Lvl 5 50 MPH";break;
		}
		levelController.Motor = motorLevel;
	}
	
	private void Acceleration()
	{
		accelLevel = Mathf.Clamp(accelLevel,1,5);
		switch(accelLevel)
		{
			case 1: accelText.text = "Lvl 1 50%";break;
			case 2: accelText.text = "Lvl 2 60%";break;
			case 3: accelText.text = "Lvl 3 70%";break;
			case 4: accelText.text = "Lvl 4 80%";break;
			case 5: accelText.text = "Lvl 5 100%";break;
		}
		levelController.Acceleration = accelLevel;
	}
	
	private void BatterLevels()
	{
		batteryLevel = Mathf.Clamp(batteryLevel,1,5);
		switch(batteryLevel)
		{
			case 1: batteryText.text = "Lvl 1 50% Max";break;
			case 2: batteryText.text = "Lvl 2 60% Max";break;
			case 3: batteryText.text = "Lvl 3 70% Max";break;
			case 4: batteryText.text = "Lvl 4 80% Max";break;
			case 5: batteryText.text = "Lvl 5 100% Max";break;
		}
		levelController.FuelTank = batteryLevel;
	}
	private void ConsumptionLevels()
	{
		wearLevel = Mathf.Clamp(wearLevel,1,5);
		switch(wearLevel)
		{
			case 1: wearText.text = "Lvl 1 -8/3Secs";break;
			case 2: wearText.text = "Lvl 2 -6/3Secs";break;
			case 3: wearText.text = "Lvl 3 -4/3Secs";break;
			case 4: wearText.text = "Lvl 4 -2/3Secs";break;
			case 5: wearText.text = "Lvl 5 -1/3Secs";break;
		}
		levelController.ConsumptionLevel = wearLevel;
	}
	private void BoostLevels()
	{
		boostLevel = Mathf.Clamp(boostLevel,1,5);
		switch(boostLevel)
		{
		case 1: boostText.text = "Lvl 1 10hp 3Secs";break;
		case 2: boostText.text = "Lvl 2 20hp 3Secs";break;
		case 3: boostText.text = "Lvl 3 30hp 3Secs";break;
		case 4: boostText.text = "Lvl 4 40hp 3Secs";break;
		case 5: boostText.text = "Lvl 5 50hp 3Secs";break;
		}
		levelController.Boost = boostLevel;
	}
	
	private void SteeringLevels()
	{
		steeringLevel = Mathf.Clamp(steeringLevel,1,5);
		switch(steeringLevel)
		{
		case 1: steeringText.text = "Lvl 1 10%";break;
		case 2: steeringText.text = "Lvl 2 30%";break;
		case 3: steeringText.text = "Lvl 3 60%";break;
		case 4: steeringText.text = "Lvl 4 90%";break;
		case 5: steeringText.text = "Lvl 5 100%";break;
		}
		levelController.SteeringSensitivity = steeringLevel;
	}
	#endregion	
}
