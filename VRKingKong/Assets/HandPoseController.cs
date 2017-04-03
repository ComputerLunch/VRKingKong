using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HandPoseController : MonoBehaviour {

    public GameObject left;
    public GameObject right;
    // Use this for initialization

    Animator animl;
    Animator animr;

    int Idle = Animator.StringToHash("Idle");
    int Point = Animator.StringToHash("Point");
    int GrabLarge = Animator.StringToHash("GrabLarge");
    int GrabSmall = Animator.StringToHash("GrabSmall");
    int GrabStickUp = Animator.StringToHash("GrabStickUp");
    int GrabStickFront = Animator.StringToHash("GrabStickFront");
    int ThumbUp = Animator.StringToHash("ThumbUp");
    int Fist = Animator.StringToHash("Fist");
    int Gun = Animator.StringToHash("Gun");
    int GunShoot = Animator.StringToHash("GunShoot");
    int PushButton = Animator.StringToHash("PushButton");
    int Spread = Animator.StringToHash("Spread");
    int MiddleFinger = Animator.StringToHash("MiddleFinger");
    int Peace = Animator.StringToHash("Peace");
    int OK = Animator.StringToHash("OK");
    int Phone = Animator.StringToHash("Phone");
    int Rock = Animator.StringToHash("Rock");
    int Natural = Animator.StringToHash("Natural");

    void Start () {
        animl = left.GetComponent<Animator>();
        animr = right.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.LHandTrigger))
        {
            animl.CrossFade(Fist, 0.6f);
            Debug.Log("prrrressed!");
        }
        if (OVRInput.GetUp(OVRInput.RawButton.LHandTrigger))
        {
            animl.CrossFade(Natural, 0.6f);
        }
    }
}
