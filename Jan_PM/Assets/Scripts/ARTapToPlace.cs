using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace : MonoBehaviour
{
    public GameObject objectToInstantiate;          // the prefab to be instantiated in the scene
    static GameObject spawnedObject;                // to hold a reference to the object instantiated

    private ARRaycastManager arRaycastManager;
    private Vector2 touchPosition;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();      // to store our hits
    
    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // determine if we have touched the screen, if true, return the touchPosition
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            // we want the first position of when we touched the screen
            touchPosition = Input.GetTouch(0).position;
            
            return true;
        }
        touchPosition = default;
        return false;
    }
    
    void Update()
    {
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        // trackable type is something in the physical environemnt that your phone is able to track (a plane)
        if(arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            // ARRaycastHits are sorted by distance, hits[0] will be the closets one
            var hitPose = hits[0].pose;

            spawnedObject = Instantiate(objectToInstantiate, hitPose.position, hitPose.rotation);
        }
    }
}
