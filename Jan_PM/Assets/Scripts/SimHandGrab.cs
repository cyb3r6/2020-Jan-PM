using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimHandGrab : MonoBehaviour
{
    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    public MovementPMJan controller;
    public float throwForce;

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
            if (collidingObject)
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
    }

    public void Grab()
    {
        heldObject.transform.SetParent(this.transform);
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
    }

    public void AdvRelease()
    {
        if (GetComponent<FixedJoint>())
        {
            Destroy(GetComponent<FixedJoint>());

            heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity * throwForce;
            heldObject = null;
        }
    }
}
