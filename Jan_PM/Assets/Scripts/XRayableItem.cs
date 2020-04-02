using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Attach this script to an object you want 
/// to xray! It must have a RENDERER component
/// </summary>

public class XRayableItem : MonoBehaviour
{    
    void Start()
    {
        if (GetComponent<Renderer>())
        {
            GetComponent<Renderer>().material.renderQueue = 3002;
        }
    }
}
