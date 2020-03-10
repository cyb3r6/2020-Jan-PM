using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRTeleportation : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport")]
    public Transform vrRig;

    private VRInput controller;
    private LineRenderer laser;
    private Vector3 hitPosition;
    private bool shouldTeleport;

        
    void Start()
    {
        controller = GetComponent<VRInput>();
        laser = GetComponent<LineRenderer>();
    }

    
    void Update()
    {
        if (controller.isThumbstickPressed)
        {
            RaycastHit hit;
            if(Physics.Raycast(controller.transform.position, controller.transform.forward, out hit))
            {
                hitPosition = hit.point;
                laser.SetPosition(0, controller.transform.position);
                laser.SetPosition(1, hitPosition);

                laser.enabled = true;

                shouldTeleport = true;
            }

        }
        else if(controller.isThumbstickPressed == false)
        {
            if (shouldTeleport == true)
            {
                vrRig.position = hitPosition;
                shouldTeleport = false;
                laser.enabled = false;
            }
        }
    }
}
