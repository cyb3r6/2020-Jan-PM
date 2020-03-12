using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text counterText;
    public bool toggle;

    float? counter;

    
    void Start()
    {
        toggle = true;
    }

    
    void Update()
    {
        if (toggle)
        {
            counter = 0f;
            toggle = false;
        }

        if (counter.HasValue)
        {
            counter += Time.deltaTime;
            counterText.text = counter.Value.ToString("F2");

            if(counter.Value > 3)
            {
                counterText.text = "3";
                counter = null;
            }
        }
    }
}
