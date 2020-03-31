using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARInstructionSteps : MonoBehaviour
{
    public GameObject mainMenuCanvas;
    public GameObject initializeHeatCanvas;
    public GameObject saltWaterCanvas;

    private List<GameObject> steps = new List<GameObject>();
    private int currentStep = 0;
    private GameObject currentCanvas;
    
    public void TurnOnInitializeHeatCanvas()
    {
        mainMenuCanvas.SetActive(false);
        initializeHeatCanvas.SetActive(true);

        steps.Clear();

        for(int i = 0; i < initializeHeatCanvas.transform.childCount - 2; i++)
        {
            steps.Add(initializeHeatCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = initializeHeatCanvas;
    }

    public void TurnOnSaltWaterCanvas()
    {
        mainMenuCanvas.SetActive(false);
        saltWaterCanvas.SetActive(true);

        steps.Clear();

        for (int i = 0; i < saltWaterCanvas.transform.childCount - 2; i++)
        {
            steps.Add(saltWaterCanvas.transform.GetChild(i).gameObject);
        }
        currentCanvas = saltWaterCanvas;
    }

    public void NextStep()
    {
        steps[currentStep].SetActive(false);

        //if(currentStep == steps.Count - 1)
        //{
        //    currentStep = 0;
        //    steps[0].SetActive(true);
        //    currentCanvas.SetActive(false);
        //    mainMenuCanvas.SetActive(true);

        //    return;
        //}

        // modulus arithemtic (%)
        currentStep = (currentStep + 1) % steps.Count;

        steps[currentStep].SetActive(true);

        if(currentStep == 0)
        {
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);
        }
    }
    public void PreviousStep()
    {
        steps[currentStep].SetActive(false);

        //if(currentStep == steps.Count - 1)
        //{
        //    currentStep = 0;
        //    steps[0].SetActive(true);
        //    currentCanvas.SetActive(false);
        //    mainMenuCanvas.SetActive(true);

        //    return;
        //}

        if (currentStep == 0)
        {
            currentCanvas.SetActive(false);
            mainMenuCanvas.SetActive(true);

            return;
        }

        // modulus arithemtic  (%)
        currentStep = (currentStep - 1) % steps.Count;

        steps[currentStep].SetActive(true);

        
    }
}
