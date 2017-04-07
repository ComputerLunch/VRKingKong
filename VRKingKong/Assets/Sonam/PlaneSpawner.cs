using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour {
	
	public GameObject planeOne; 
	public GameObject planeTwo;
	public GameObject planeThree; 
	public GameObject spawnPlane;  // this is where the plane spawns from 
	public Transform[] spawnPlanePoints;


	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {		
		if (Input.GetKeyDown ("space")) {
			Instantiate(planeOne,spawnPlanePoints[Random.Range(0,spawnPlanePoints.Length)].GetComponent<Transform>().position, Quaternion.identity);
			Instantiate(planeTwo,spawnPlanePoints[Random.Range(0,spawnPlanePoints.Length)].GetComponent<Transform>().position, Quaternion.identity);
			Instantiate(planeThree,spawnPlanePoints[Random.Range(0,spawnPlanePoints.Length)].GetComponent<Transform>().position, Quaternion.identity);
		}
			
	}
}
