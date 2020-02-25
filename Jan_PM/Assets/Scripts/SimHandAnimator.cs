using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandAnimator : MonoBehaviour
{
    private Animator simHandAnimator;
    
    void Awake()
    {
        simHandAnimator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        // need to detect a mouse input
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosed", true);
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            simHandAnimator.SetBool("IsClosed", false);
        }

    }
}
