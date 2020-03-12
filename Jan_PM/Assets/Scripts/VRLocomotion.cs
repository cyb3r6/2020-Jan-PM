using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRLocomotion : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport")]
    public Transform vrRig;

    [Tooltip("This is the transform we want use as a forward direction. Can be your head or hand")]
    public Transform director;

    private VRInput controller;
    private Vector3 PlayerForward;
    private Vector3 PlayerRight;

    void Start()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        PlayerForward = director.forward;
        PlayerForward.y = 0f;
        PlayerForward.Normalize();

        PlayerRight = director.right;
        PlayerRight.y = 0f;
        PlayerRight.Normalize();

        vrRig.Translate(PlayerForward * controller.thumbstick.y * Time.deltaTime);
        vrRig.Translate(PlayerRight * controller.thumbstick.x * Time.deltaTime);
    }
}
