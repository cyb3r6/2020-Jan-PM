using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallGameManager : MonoBehaviour
{
    public static WreckingBallGameManager _instance;

    public int numberOfCubesDestroyed;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.Log("There's two game managers in the scene!");
        }
    }

   
    public void CountCubesDestroyed()
    {
        numberOfCubesDestroyed = numberOfCubesDestroyed + 1;        
    }
}
