using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedButton : MonoBehaviour
{
    public Animator buttonAnim;
    public GameObject otherButton;
    private bool enable;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            buttonAnim.SetTrigger("Press");            
            otherButton.SetActive(enable);
            enable = !enable;
        }
    }
}
