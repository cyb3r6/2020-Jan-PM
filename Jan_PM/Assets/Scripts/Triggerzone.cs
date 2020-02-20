using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggerzone : MonoBehaviour
{
    public Animator bridgeAnim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bridgeAnim.SetBool("RaiseBridge", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            bridgeAnim.SetBool("RaiseBridge", false);
        }
    }
}
