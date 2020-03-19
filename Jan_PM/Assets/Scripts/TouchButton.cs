using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TouchButton : MonoBehaviour
{
    public Transform buttonTransform, downTransform;
    public VideoPlayer videoPlane;
    private Vector3 originalPosition;

    
    void Start()
    {
        originalPosition = buttonTransform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            buttonTransform.position = downTransform.position;
            videoPlane.Play();
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
