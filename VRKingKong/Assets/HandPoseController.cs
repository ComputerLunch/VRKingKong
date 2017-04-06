using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HandPoseController : MonoBehaviour {

    public GameObject hand;
    Animator anim;

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

    bool gripPressed = false;
    bool triggerPressed = false;
    bool grabbed = false;

    void Start () {
        anim = hand.GetComponent<Animator>();
        anim.CrossFade(GrabLarge, 0.6f);

        if (GetComponent<VRTK_ControllerEvents>() == null)
        {
            Debug.LogError("VRTK_ControllerEvents_ListenerExample is required to be attached to a Controller that has the VRTK_ControllerEvents script attached to it");
            return;
        }

        GetComponent<VRTK_ControllerEvents>().GripPressed += new ControllerInteractionEventHandler(DoGripPressed);
        GetComponent<VRTK_ControllerEvents>().GripReleased += new ControllerInteractionEventHandler(DoGripReleased);

        GetComponent<VRTK_ControllerEvents>().TriggerPressed += new ControllerInteractionEventHandler(DoTriggerPressed);
        GetComponent<VRTK_ControllerEvents>().TriggerReleased += new ControllerInteractionEventHandler(DoTriggerReleased);

        GetComponent<VRTK_InteractGrab>().ControllerGrabInteractableObject += new ObjectInteractEventHandler(GrabbedWall);
        GetComponent<VRTK_InteractGrab>().ControllerUngrabInteractableObject += new ObjectInteractEventHandler(UngrabbedWall);

        
    }

    // Update is called once per frame
    private void DebugLogger(uint index, string button, string action, ControllerInteractionEventArgs e)
    {
        Debug.Log("Controller on index '" + index + "' " + button + " has been " + action
                + " with a pressure of " + e.buttonPressure + " / trackpad axis at: " + e.touchpadAxis + " (" + e.touchpadAngle + " degrees)");
    }

    private void GrabbedWall(object sender, ObjectInteractEventArgs e)
    {
        grabbed = true;
        anim.CrossFade(GrabStickFront, 0.6f);
        GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(1000, 1f, 0);
    }

    private void UngrabbedWall(object sender, ObjectInteractEventArgs e)
    {
        grabbed = false;
        anim.CrossFade(GrabLarge, 0.6f);
        GetComponent<VRTK_ControllerActions>().TriggerHapticPulse(500, 0.5f, 0);
    }


    private void DoGripPressed(object sender, ControllerInteractionEventArgs e)
    {
        gripPressed = true;
        DebugLogger(e.controllerIndex, "GRIP", "pressed", e);

        //if(triggerPressed) anim.CrossFade(Fist, 0.6f);
        if(grabbed) anim.CrossFade(GrabStickFront, 0.6f);
        else anim.CrossFade(Fist, 0.6f);
    }

    private void DoGripReleased(object sender, ControllerInteractionEventArgs e)
    {
        gripPressed = false;
        if (triggerPressed) anim.CrossFade(GrabStickUp, 0.6f);
        else anim.CrossFade(GrabLarge, 0.6f);

        DebugLogger(e.controllerIndex, "GRIP", "released", e);
    }

    private void DoTriggerPressed(object sender, ControllerInteractionEventArgs e)
    {
        triggerPressed = true;
        if (gripPressed) anim.CrossFade(Fist, 0.6f);
        else anim.CrossFade(GrabStickUp, 0.6f);
        DebugLogger(e.controllerIndex, "TRIGGER", "pressed", e);
    }

    private void DoTriggerReleased(object sender, ControllerInteractionEventArgs e)
    {
        triggerPressed = false;
        if (gripPressed) anim.CrossFade(GrabStickFront, 0.6f);
        else anim.CrossFade(GrabLarge, 0.6f);
        DebugLogger(e.controllerIndex, "TRIGGER", "released", e);
    }
}
