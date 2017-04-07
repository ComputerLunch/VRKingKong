using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyTowardsPoint : MonoBehaviour {

	public Transform target;
	public float speed;

	// Use this for initialization
	void Start () {
		//target = GameObject.FindGameObjectWithTag("MainCamera").transform;	
		print(target);

	}
	
	// Update is called once per frame
	void Update () {
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}

