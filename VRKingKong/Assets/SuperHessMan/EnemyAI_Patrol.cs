using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Patrol : MonoBehaviour {

	public Transform[] Waypoints;
	public float Speed;
	public int curWayPoint;
	public bool doPatrol = true;
	public Vector3 Target;
	public Vector3 MoveDirection;
	public Vector3 Velocity;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curWayPoint < Waypoints.Length) {
			Target = Waypoints [curWayPoint].position;
			MoveDirection = Target - transform.position;
			Velocity = GetComponent<Rigidbody> ().velocity;

			if (MoveDirection.magnitude < 1) {
				curWayPoint++;
			} else {
				Velocity = MoveDirection.normalized * Speed;
			}
		} else {
			if (doPatrol) {
				curWayPoint = 0;
			} else {
				Velocity = Vector3.zero;
			}
		}
		GetComponent<Rigidbody> ().velocity = Velocity;

//		Vector3 targetDir = Target - transform.position;
//		float step = Speed * Time.deltaTime;
//		Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0F);
//		Debug.DrawRay(transform.position, newDir, Color.red);

		transform.LookAt (Target);
		GetComponent<Transform> ().rotation = new Quaternion (-90f, transform.rotation.y, transform.rotation.z, transform.rotation.w);

	}
}
