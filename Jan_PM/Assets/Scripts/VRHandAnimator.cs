using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRHandAnimator : MonoBehaviour
{
    private Animator handAnimator;
    private VRInput controller;
    void Awake()
    {
        handAnimator = GetComponentInChildren<Animator>();
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller && handAnimator)
        {
            handAnimator.Play("Fist Closing", 0, controller.gripValue);
        }
    }
}
