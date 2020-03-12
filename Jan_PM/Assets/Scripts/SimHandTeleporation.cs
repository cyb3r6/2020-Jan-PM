using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandTeleporation : MonoBehaviour
{
    [Tooltip("This is the transform we want to teleport")]
    public Transform simHand;

    private MovementPMJan movementPMJanScript;
    private LineRenderer laser;
    private Vector3 hitPosition;
    private bool shouldTeleport;

    void Awake()
    {
        movementPMJanScript = GetComponent<MovementPMJan>();
        laser = GetComponent<LineRenderer>();
    }
    
    void Update()
    {
        if (movementPMJanScript.isButtonPressed)
        {
            RaycastHit hit;
            if(Physics.Raycast(simHand.position, simHand.forward, out hit))
            {
                hitPosition = hit.point;
                laser.SetPosition(0, simHand.position);
                laser.SetPosition(1, hitPosition);

                laser.enabled = true;

                shouldTeleport = true;                

            }
        }
        else if(movementPMJanScript.isButtonPressed == false)
        {
            if(shouldTeleport == true)
            {
                float offset = Offset();

                simHand.position = new Vector3(hitPosition.x, hitPosition.y + offset, hitPosition.z);
                shouldTeleport = false;
                laser.enabled = false;
            }
        }
    }

    private float Offset()
    {
        RaycastHit offsetHit;
        if(Physics.Raycast(simHand.position, -simHand.up, out offsetHit))
        {
            Vector3 distance = simHand.position - offsetHit.point;

            return distance.y;
        }
        else
        {
            return default;     // default value of a float = 0.0f, default of a bool = false, string = null
        }
    }
}
