using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    public Transform chasee;
    public float moveSpeed;
    public float stoppingDistance;
    
    void Update()
    {
        transform.LookAt(chasee);

        if(Vector3.Distance(transform.position, chasee.position) > stoppingDistance)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
}
