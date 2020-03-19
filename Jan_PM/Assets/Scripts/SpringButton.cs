using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringButton : MonoBehaviour
{
    public ShotCounter shotCounterScript;

    private void OnTriggerEnter(Collider other)
    {
        shotCounterScript.shotsFired = 0;
    }
}
