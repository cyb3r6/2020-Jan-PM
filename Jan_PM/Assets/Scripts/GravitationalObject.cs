using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitationalObject : MonoBehaviour
{
    public Rigidbody rigidBody;

    public Vector3 endForce;        // the force to apply in the fixedUpdate
    public Vector3 initialForce;    // the force to apply orbiting behaviour

    void Awake()
    {
        Gravity.gravitationalObjects.Add(this);

        rigidBody = GetComponent<Rigidbody>();
    }

    public void AddEndForce()
    {
        if(endForce != Vector3.zero)
        {
            rigidBody.AddForce(endForce);
            endForce = Vector3.zero;
        }
    }
}
