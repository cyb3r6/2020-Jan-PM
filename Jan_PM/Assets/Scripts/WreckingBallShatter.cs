using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallShatter : MonoBehaviour
{
    public GameObject bigAngryJoe, miniAngryJoes;
    public int numberofBigCollision = 20;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 5)
        {
            
            numberofBigCollision--;
            if(numberofBigCollision == 0)
            {
                bigAngryJoe.SetActive(false);
                miniAngryJoes.SetActive(true);
            }            
        }
    }
}
