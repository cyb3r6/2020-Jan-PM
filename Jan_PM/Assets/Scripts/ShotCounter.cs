using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCounter : MonoBehaviour
{
    public Text canvasText;
    public int shotsFired;

    // check how many shots have been fired
    // print to text
    void Update()
    {
        canvasText.text = "Shots fired! " + shotsFired;
    }
}
