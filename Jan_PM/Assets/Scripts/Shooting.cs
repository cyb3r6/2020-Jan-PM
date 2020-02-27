﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject prefab;
    GameObject temp;
    public Transform spawnPoint;
    public float shootingForce;
    public ShotCounter shotCounterScript;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            temp = Instantiate(prefab, spawnPoint.position, spawnPoint.rotation);

            temp.GetComponent<Rigidbody>().AddForce(temp.transform.forward * shootingForce);

            Destroy(temp, 5);
            shotCounterScript.shotsFired++;
        }
    }
}
