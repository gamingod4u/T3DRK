using UnityEngine;
using System.Collections;

public class WheelsController : MonoBehaviour 
{
	
	
	public GameObject[] wheelColliders;
	public GameObject[] wheelGraphics;
	
	private Car_Motor carMotor;
	private Ray ray;
	private RaycastHit rayHit;
	
	public int hitCount = 0;
	
	
	
	void Start()
	{
		carMotor = Car_Motor.instance;
		
	}

	// Update is called once per frame
	void Update () 
	{
		if(carMotor.CurrentSpeed != 0)
		{
			for(int i = 0; i < wheelColliders.Length; i++)
			{
				wheelGraphics[i].transform.Rotate(carMotor.CurrentSpeed *10,0,0);
				if(Physics.Raycast(wheelColliders[i].transform.position, Vector3.down, out rayHit, 1))
				{
					if(rayHit.transform.tag == "Ground")
						hitCount++;
				}														
				
			}
			
			if(hitCount < 2)
				carMotor.Ground = false;
			else if(hitCount >= 2)
				carMotor.Ground = true;
				
				Debug.Log(hitCount);
				hitCount = 0;
		}
				
	}
	
	
	
}
