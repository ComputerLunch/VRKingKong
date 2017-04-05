using UnityEngine;
using System.Collections;

public class VRWalker : MonoBehaviour {

	CharacterController controller;
	float currentSpeed = 5.0F;

	public GameObject cam;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {

		ForwardMovementOnKeys();
	}
		
	void ForwardMovementOnKeys()
	{
		Vector3 forward = cam.transform.TransformDirection(Vector3.forward);
		Vector3 right = cam.transform.TransformDirection(Vector3.right);

		float horizontal = Input.GetAxis("Horizontal");
		float vertical = Input.GetAxis("Vertical");

		Vector3 horizontalVec3 = right * horizontal * currentSpeed;
		Vector3 verticalVec3 = forward * vertical * currentSpeed;

		controller.SimpleMove( horizontalVec3 + verticalVec3);
	}
}
