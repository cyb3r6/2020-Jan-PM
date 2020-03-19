using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    private VRInput controller;

    private bool gripHeld;
    public Transform snapPosition;
    public float throwForce = 1f;

    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.gripValue > 0.5f && gripHeld == false)
        {
            if (collidingObject && collidingObject.GetComponent<Rigidbody>())
            {
                gripHeld = true;

                heldObject = collidingObject;

                //Grab();
                AdvGrab();
            }
        }
        else if(controller.gripValue < 0.5f && gripHeld == true)
        {
            if (heldObject)
            {
                gripHeld = false;

                //Release();
                AdvRelease();
            }
        }

        #region Using BroadcastMessage
        /*
        if (Input.GetKeyDown(KeyCode.Mouse0) && heldObject)
        {
            heldObject.BroadcastMessage("Interactable");
        }
        */
        #endregion
    }

    private void OnTriggerEnter(Collider other)
    {
        collidingObject = other.gameObject;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == collidingObject)
        {
            collidingObject = null;
        }
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

        var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
        if (grabbable)
        {
            grabbable.hand = this.gameObject;
            grabbable.isBeingHeld = true;
            grabbable.vrGrab = this;
            grabbable.controller = controller;
        }
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            var grabbable = heldObject.GetComponent<GrabbableObjectVR>();
            if (grabbable)
            {
                grabbable.hand = null;
                grabbable.isBeingHeld = false;
                grabbable.vrGrab = null;
                grabbable.controller = null;
            }

            Destroy(GetComponent<FixedJoint>());
            heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;
            heldObject = null;
        }
    }
}
