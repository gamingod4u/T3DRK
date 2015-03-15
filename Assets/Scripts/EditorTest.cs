using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class EditorTest : MonoBehaviour 
{
	public bool on = false;
	
	// Update is called once per frame
	void Update ()
	{
		if(Input.GetKeyDown(KeyCode.E))
			if(on)
				on = false;
			else 
				on = true;
				
				
		if(on)
		Debug.Log(transform.localEulerAngles.x);
	}
}
