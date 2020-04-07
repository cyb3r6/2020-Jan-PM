using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchScript : MonoBehaviour
{
    public float chance = 0.1f;

    private Renderer ethanRenderer;
    WaitForSeconds loopWait = new WaitForSeconds(0.1f);
    WaitForSeconds loopDuration = new WaitForSeconds(0.1f);

    void Awake()
    {
        ethanRenderer = GetComponent<Renderer>();
    }

    IEnumerator Start()
    {
        while (true)
        {
            float glitch = Random.Range(0f, 1f);
            if(glitch <= chance)
            {
                StartCoroutine(Glitch());
            }
            yield return loopWait;
        }

       
    }

    IEnumerator Glitch()
    {
        loopDuration = new WaitForSeconds(Random.Range(0.5f, 0.25f));
        ethanRenderer.material.SetFloat("_Amplitude", Random.Range(100f, 300f));
        ethanRenderer.material.SetFloat("_Frequency", Random.Range(1f, 10f));
        ethanRenderer.material.SetFloat("_Amount", 1f);
        ethanRenderer.material.SetFloat("_CutoutThreshold", 0.29f);
        yield return loopDuration;
        ethanRenderer.material.SetFloat("_Amount", 0f);
        ethanRenderer.material.SetFloat("_CutoutThreshold", 0f);
    }
   
}
