using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : GrabbableObjectSimHand
{
    public GameObject prefab;
    GameObject temp;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;

    //private GrabbableObjectSimHand grabbableSimHand;

    void Start()
    {
        //grabbableSimHand = GetComponent<GrabbableObjectSimHand>();
    }

    void Update()
    {
        if (isBeingHeld == true)
        {
            if (simHandController.mouseLeftHeld == true)
            {
                Interactable();
            }
        }
    }

    public void Interactable()
    {
        temp = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);
        temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * shootingForce);
        Destroy(temp, 5);
        shotCounterScript.shotsFired++;
    }
}
