using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour 
{
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
	
	// Update is called once per frame
	
}
