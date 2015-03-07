﻿using UnityEngine;
using System.Collections;

public class InputController : MonoBehaviour 
{
	public enum InputType{mobile, keyboard};
	public enum SteeringType{keyboard, tilt, touch};
	public Car_Motor carMotor;

	public InputType input;
	public SteeringType steering;

	private bool onPaused = false;


	void Start()
	{
		carMotor = GameObject.FindGameObjectWithTag("Player").GetComponent<Car_Motor>();
	}

	void Update()
	{
		switch(input)
		{
		case InputType.mobile:
		{
			SwitchMobileSteering();
		}
			break;
		case InputType.keyboard:
		{
			if(Input.GetKeyDown(KeyCode.RightArrow))
			{
				if(carMotor.steeringWheel < 1f)		
					carMotor.steeringWheel += .05f;
			}
			else if(Input.GetKeyDown(KeyCode.LeftArrow))
			{
				if(carMotor.steeringWheel > -1f)
					carMotor.steeringWheel -= .05f;
			}
			else
			{
				if(carMotor.steeringWheel > 0.5f)
					carMotor.steeringWheel -= .15f;
				else if(carMotor.steeringWheel < 0.5f)
					carMotor.steeringWheel += .15f;
				else 
					carMotor.steeringWheel = 0f;
			}
		}
			break;
		}		
	}


	private void SwitchMobileSteering()
	{
		switch(steering)
		{
		case SteeringType.tilt:
		{
			if(Input.acceleration.x > 0.05f)
			{
				if(carMotor.steeringWheel < 1f)		
					carMotor.steeringWheel += .05f;
			}
			else if(Input.acceleration.x < -0.05f)
			{
				if(carMotor.steeringWheel > -1f)
					carMotor.steeringWheel -= .05f;
			}
			else
			{
				if(carMotor.steeringWheel > 0.5f)
					carMotor.steeringWheel -= .15f;
				else if(carMotor.steeringWheel < 0.5f)
					carMotor.steeringWheel += .15f;
				else 
					carMotor.steeringWheel = 0f;
			}

		}break;
		case SteeringType.touch:
		{
			
		}
			break;
		}
	}


	public void OnPause()
	{
		if(!onPaused)
		{
			Time.timeScale = 0;
			onPaused = true;
		}
		else
		{
			Time.timeScale = 1;
			onPaused = false;
		}
	}

	public void OnUnPaused()
	{
		Time.timeScale = 1;
		Debug.Log("This happened");
	}
}
