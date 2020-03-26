using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public HingeLever upDownLeverController, forwardBackwardLeverController, rightLeftLeverController;
    public float speed;
    public float deadZone = 0.05f;
    
    void Update()
    {
        if(Mathf.Abs(upDownLeverController.JointAngle()) > deadZone)
            transform.position = transform.position + transform.up * Time.deltaTime * speed * upDownLeverController.JointAngle();

        if (Mathf.Abs(forwardBackwardLeverController.JointAngle()) > deadZone)
            transform.position = transform.position + transform.forward * Time.deltaTime * speed * forwardBackwardLeverController.JointAngle();

        if (Mathf.Abs(rightLeftLeverController.JointAngle()) > deadZone)
            transform.position = transform.position + transform.right * Time.deltaTime * speed * rightLeftLeverController.JointAngle();
    }
}
