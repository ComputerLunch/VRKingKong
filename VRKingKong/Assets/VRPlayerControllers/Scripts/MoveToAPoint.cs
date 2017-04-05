using UnityEngine;
using System.Collections;

public class MoveToAPoint : MonoBehaviour {

	public float moveSpeed = 3.0f;
	public Vector3 targetPoint;

	public bool warp = false;

	CharacterController cc;

	void Start(){

		cc = GetComponent<CharacterController>();

		targetPoint = cc.transform.position;
	}

	void Update () {
		//Given some means of determining a target point.
		if(warp){
			WarpTowardsTarget (targetPoint);
		}else{
			MoveTowardsTarget (targetPoint);
		}
	}

	void WarpTowardsTarget(Vector3 target) {

		cc.transform.position = target;
	}

	void MoveTowardsTarget(Vector3 target) {
		
		var offset = target - transform.position;
		//Get the difference.
		if(offset.magnitude > .1f) {
			//If we're further away than .1 unit, move towards the target.
			//The minimum allowable tolerance varies with the speed of the object and the framerate. 
			// 2 * tolerance must be >= moveSpeed / framerate or the object will jump right over the stop.
			offset = offset.normalized * moveSpeed;
			//normalize it and account for movement speed.
			cc.Move(offset * Time.deltaTime);
			//actually move the character.
		}
	}
}
