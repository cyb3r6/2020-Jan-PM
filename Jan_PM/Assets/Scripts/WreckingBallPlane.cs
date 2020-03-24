using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallPlane : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Destroyable")
        {
            // can either destroy cubes
            //Destroy(other.gameObject);

            // or i can just turn off the renderer
            other.GetComponent<Renderer>().enabled = false;

            WreckingBallGameManager._instance.CountCubesDestroyed();
        }
    }
}
