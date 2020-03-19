using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingVR : GrabbableObjectVR
{
    public GameObject prefab;
    GameObject temp;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;
    private bool enable = false;

    
    void Update()
    {
        if (isBeingHeld == true)
        {
            if (controller.isTriggerPressed && !enable)
            {
                enable = true;
                Interactable();
            }
            if (controller.isTriggerPressed == false && enable)
            {
                enable = false;
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
