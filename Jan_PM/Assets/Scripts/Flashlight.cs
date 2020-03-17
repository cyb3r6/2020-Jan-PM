using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : GrabbableObjectSimHand
{
    private Light flashlight;
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
            if(simHandController.mouseLeftHeld == true)
            {
                Interactable();
            }
        }
    }

    public void Interactable()
    {
        flashlight.enabled = !flashlight.enabled;
    }
}
