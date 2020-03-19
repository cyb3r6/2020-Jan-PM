using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightVR : GrabbableObjectVR
{
    private Light flashlight;
    private bool enable = false;
    //private GrabbableObjectSimHand grabbableSimHand;

    void Start()
    {
        flashlight = GetComponentInChildren<Light>();
        //grabbableSimHand = GetComponent<GrabbableObjectSimHand>();
    }

    
    void Update()
    {
        if(isBeingHeld == true)
        {
            if(controller.isTriggerPressed && !enable)
            {
                enable = true;
                Interactable();
            }
            if(controller.isTriggerPressed == false && enable)
            {
                enable = false;
            }
        }
    }

    public void Interactable()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
