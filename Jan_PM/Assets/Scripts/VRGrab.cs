using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRGrab : MonoBehaviour
{
    public GameObject collidingObject;      // what we're touching
    public GameObject heldObject;           // what we're holding

    private VRInput controller;

    private bool gripHeld;
    
    void Awake()
    {
        controller = GetComponent<VRInput>();
    }

    
    void Update()
    {
        if(controller.gripValue > 0.5f && gripHeld == false)
        {
            if (collidingObject)
            {
                gripHeld = true;

                heldObject = collidingObject;

                Grab();
            }
        }
        else if(controller.gripValue < 0.5f && gripHeld == true)
        {
            if (heldObject)
            {
                gripHeld = false;

                Release();
            }
        }
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
        Debug.Log("Grabbed!");
        heldObject.transform.SetParent(this.transform);
        heldObject.GetComponent<Rigidbody>().useGravity = false;
        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Release()
    {
        Debug.Log("Released!");
        heldObject.GetComponent<Rigidbody>().useGravity = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;

        heldObject.GetComponent<Rigidbody>().velocity = controller.handVelocity;

        heldObject.transform.SetParent(null);
        heldObject = null;
    }
}
