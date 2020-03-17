using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    public MovementPMJan controller;
    public float throwForce;
    public bool mouseLeftHeld;

    public Transform snapPosition;

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            // grab? nay nay
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                heldObject = collidingObject;

                //Grab();
                AdvGrab();
            }
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            if (heldObject)
            {
                //Release();
                AdvRelease();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            mouseLeftHeld = true;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && heldObject)
        {
            mouseLeftHeld = false;
        }

        #region Using BroadcastMessage
        
        if (Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            heldObject.BroadcastMessage("Interactable");
        }
        
        #endregion

    }

    public void Grab()
    {
        heldObject.transform.SetParent(snapPosition);
        heldObject.transform.localPosition = Vector3.zero;
        heldObject.GetComponent<Rigidbody>().useGravity = false;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;

        
    }
    public void Release()
    {        

        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;
        heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;

        heldObject.transform.SetParent(null);
        heldObject = null;
    }

    public void AdvGrab()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 2000;
        heldObject.transform.rotation = this.transform.rotation;
        fx.connectedBody = heldObject.GetComponent<Rigidbody>();

        var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.simHandController = this;
        }
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectSimHand>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.simHandController = null;
            }

            Destroy(GetComponent<FixedJoint>());
            heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;
            heldObject = null;
        }
    }
}
