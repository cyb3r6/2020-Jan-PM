﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;         // if isLeftHand is true, then this script is attached to the left hand
    public float gripValue;
    public float triggerValue;
    private string gripAxis;
    private string triggerAxis;

    void Awake()
    {
        if (isLeftHand)
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);
    }
}
