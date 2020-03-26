using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallResetButton : MonoBehaviour
{
    public Transform buttonTransform, downTransform;
    private Vector3 originalPosition;

    public delegate void ButtonPressedEvent();
    public ButtonPressedEvent OnButtonPressed;
    
    void Start()
    {
        originalPosition = buttonTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = downTransform.position;
            OnButtonPressed();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = originalPosition;
        }
    }
}
