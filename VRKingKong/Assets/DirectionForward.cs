using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionForward : MonoBehaviour {

	Vector3 LastPosition = Vector3.zero;
	Vector3 Direction = Vector3.zero;
	public float RotateSpeed = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Direction = transform.position - LastPosition;
		if (Direction != Vector3.zero) {
			//transform.forward = Direction.normalized;
			transform.forward = Vector3.Lerp(transform.forward, Direction.normalized, RotateSpeed * Time.deltaTime);
		}
		LastPosition = transform.position;

	}
}
