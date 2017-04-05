using UnityEngine;
using System.Collections;

public class RayCastHitDetection : MonoBehaviour {

	public MoveToAPoint moveToAPoint ;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 fwd = transform.TransformDirection(Vector3.forward);

		float distance = 10.0f;
		bool didHit = false;

		RaycastHit hit;
	
		if (Physics.Raycast(transform.position, fwd * distance , out hit)){
		
			//print("Found an object ("+hit.collider.gameObject.name+")- distance: " + hit.distance);

			distance = hit.distance;
			didHit = true;

			// Load prefab from resource folder
			if(Input.GetButtonDown("Fire1")){

				GameObject marker = Instantiate(Resources.Load("Marker"), hit.point, Quaternion.identity) as GameObject;
				Destroy(marker, 4.0f);


				if(moveToAPoint){
					moveToAPoint.targetPoint = hit.point;
				}

			}
		}
			
		// Draw a line 
		Debug.DrawRay(transform.position , fwd * distance , didHit ? Color.red : Color.green , 0.1f );

	}
}
