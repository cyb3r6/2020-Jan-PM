using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tractorbeam : GrabbableObjectSimHand
{
    public Transform startingPoint;
    public float tractorBeamSpeed;
    private RaycastHit hit;
    private Transform hitTransform;
    private LineRenderer tractorBeam;
    private Rigidbody hitRigidBody;

    private void Start()
    {
        tractorBeam = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (simHandController.mouseLeftHeld == true)
            {
                Interactable();
            }
            else
            {
                Drop();
            }
        }
    }

    public void Interactable()
    {
        if(Physics.Raycast(startingPoint.position, transform.forward, out hit))
        {
            hitTransform = hit.transform;
            tractorBeam.enabled = true;
            tractorBeam.SetPosition(0, startingPoint.position);
            tractorBeam.SetPosition(1, hit.point);
            hitRigidBody = hitTransform.GetComponent<Rigidbody>();

            if (hitRigidBody && !hitRigidBody.isKinematic)
            {
                hitTransform.position = Vector3.Lerp(hitTransform.position, startingPoint.position, Time.deltaTime);
                //hitTransform.position = Vector3.MoveTowards(hitTransform.position, startingPoint.position, Time.deltaTime * tractorBeamSpeed);
                hitRigidBody.useGravity = false;
            }
            else
            {
                hitTransform = null;
            }
        }
        else
        {
            Drop();
        }
    }
    public void Drop()
    {
        tractorBeam.enabled = false;
        if (hitTransform)
        {
            hitRigidBody.useGravity = true;
            hitTransform = null;
            hitRigidBody = null;
        }
    }
}
