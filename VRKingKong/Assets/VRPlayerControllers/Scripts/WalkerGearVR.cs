using UnityEngine;
using System.Collections;

public class WalkerGearVR : MonoBehaviour {

	public enum GearVRControlType
	{
		MOVEMENT_SWIPE,
		MOVEMENT_TAP,
	}

	CharacterController controller;
	float currentSpeed = 5.0F;

	public GameObject cam;

	public GearVRControlType controlType = GearVRControlType.MOVEMENT_TAP;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {


		if(controlType == GearVRControlType.MOVEMENT_TAP){
			// Tap and Hold
			ForwardMovementOnHold();
		}else{
			// Swipe
			ForwardMovementOnSwipe();
		}
	}


	void ForwardMovementOnHold()
	{
		//Define the forward vector using your facing direction
		Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
	
		// If the touchpad is being held down, move forward in the direction you are facing.
		if (Input.GetButton("Fire1"))
		{
			
			controller.SimpleMove(forward * currentSpeed);
		}
	}



	void ForwardMovementOnSwipe()
	{
		//Define the forward vector using your facing direction
		Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
		Vector3 left = cam.transform.TransformDirection(Vector3.left);


		// If the touchpad is being held down, move forward in the direction you are facing.
		if (Input.GetButton("Fire1"))
		{
			// Read input
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			// Controls Swiping on Gear VR
			#if UNITY_ANDROID
			if (Mathf.Abs(vertical) < 0.1f)
			{
				vertical = GearVRInput.GetAxisY;
			}
			if (Mathf.Abs(horizontal) < 0.1f)
			{
				horizontal = GearVRInput.GetAxisX;
			}
			#endif


			Vector3 horizontalVec3 = forward * horizontal * currentSpeed;
			Vector3 verticalVec3 = left * vertical * -1f * currentSpeed;

			controller.SimpleMove( horizontalVec3 + verticalVec3);
	
		}
	}
}
