using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public static List<GravitationalObject> gravitationalObjects = new List<GravitationalObject>();

    [Range(-20, 20)]
    public float gravitationalConstant;
    

    
    void FixedUpdate()
    {
        int loopCount = 1;

        foreach(GravitationalObject objectGravity in gravitationalObjects)
        {
            for(int i = loopCount; i < gravitationalObjects.Count; i++)
            {
                Rigidbody objectGravityRigidBody = objectGravity.rigidBody;
                CalculateGravity(objectGravity, gravitationalObjects[i], objectGravityRigidBody, gravitationalObjects[i].rigidBody);
            }
            loopCount++;
        }
        AddGravitationForce();
    }


    private void CalculateGravity(GravitationalObject Object1, GravitationalObject Object2, Rigidbody m1, Rigidbody m2)
    {
        Vector3 r = m1.position - m2.position;

        if(r == Vector3.zero)
        {
            return;
        }

        Vector3 force = r.normalized * (gravitationalConstant * m1.mass * m2.mass / Mathf.Pow(r.magnitude, 2));

        Object1.endForce -= force;
        Object2.endForce += force;
    }

    private void AddGravitationForce()
    {
        foreach(GravitationalObject tempObject in gravitationalObjects)
        {
            tempObject.AddEndForce();
        }
    }
}
