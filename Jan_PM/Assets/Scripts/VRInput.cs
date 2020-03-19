using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInput : MonoBehaviour
{
    public bool isLeftHand;         // if isLeftHand is true, then this script is attached to the left hand
    public float gripValue;
    public float triggerValue;
    public bool isThumbstickPressed;
    public bool isTriggerPressed;
    public Vector2 thumbstick;


    private string gripAxis;
    private string triggerAxis;
    private string thumbstickButton;
    private string thumbstickX;
    private string thumbstickY;
    private float thumbstickXValue;
    private float thumbstickYValue;

    public Vector3 handVelocity;
    private Vector3 previousPosition;

    void Awake()
    {
        if (isLeftHand)
        {
            gripAxis = "LeftGrip";
            triggerAxis = "LeftTrigger";
            thumbstickButton = "LeftThumbstickButton";
            thumbstickX = "LeftThumbstickX";
            thumbstickY = "LeftThumbstickY";
        }
        else
        {
            gripAxis = "RightGrip";
            triggerAxis = "RightTrigger";
            thumbstickButton = "RightThumbstickButton";
            thumbstickX = "RightThumbstickX";
            thumbstickY = "RightThumbstickY";
        }
    }

    
    void Update()
    {
        gripValue = Input.GetAxis(gripAxis);
        triggerValue = Input.GetAxis(triggerAxis);
        thumbstickXValue = Input.GetAxis(thumbstickX);
        thumbstickYValue = Input.GetAxis(thumbstickY);

        thumbstick = new Vector2(thumbstickXValue, thumbstickYValue);

        if (Input.GetButtonDown(thumbstickButton))
        {
            isThumbstickPressed = true;
        }
        else if (Input.GetButtonUp(thumbstickButton))
        {
            isThumbstickPressed = false;
        }
        if(Input.GetAxis(triggerAxis) > 0.5f)
        {
            isTriggerPressed = true;
        }
        if (Input.GetAxis(triggerAxis) < 0.5f)
        {
            isTriggerPressed = false;
        }

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;
    }
}
