/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

// The target we are following
var target : GameObject;
// The distance in the x-z plane to the target
var distance = 10.0;
// the height we want the camera to be above the target
var height = 5.0;
// How much we 
var heightDamping = 2.0;
var rotationDamping = 3.0;
var thisPosition:Vector3;
var thisRotation:Quaternion;
// Place the script in the Camera-Control group in the component menu
@script AddComponentMenu("Camera-Control/Smooth Follow")

// TESTING
var temp : GameObject;
temp = new GameObject();


function Awake()
{
 
 target = GameObject.FindGameObjectWithTag("Player");
}
function LateUpdate () {
	// Early out if we don't have a target
	if (!target)
		target = GameObject.FindGameObjectWithTag("Player");

	
	// Calculate the current rotation angles
	var wantedRotationAngle = target.transform.eulerAngles.y;
	var wantedHeight = target.transform.position.y + height;
		
	var currentRotationAngle = transform.eulerAngles.y;
	var currentHeight = transform.position.y;
	
	// Damp the rotation around the y-axis
	currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

	// Damp the height
	currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);

	// Convert the angle into a rotation
	var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
	// Set the position of the camera on the x-z plane to:
	// distance meters behind the target
	transform.position = target.transform.position;
	transform.position -= currentRotation * Vector3.forward * distance;

	// Set the height of the camera
	transform.position.y = currentHeight;
	
	// Always look at the target
	temp.transform.position = target.transform.position;
	temp.transform.position += Vector3( 0, 1.5, 0 );
	transform.LookAt (temp.transform);
}