using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WreckingBallCounter : MonoBehaviour
{
    public Text canvasText;

   

    void Update()
    {
        canvasText.text = WreckingBallGameManager._instance.numberOfCubesDestroyed.ToString();
    }
}
