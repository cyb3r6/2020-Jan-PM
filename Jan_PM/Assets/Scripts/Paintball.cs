using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paintball : MonoBehaviour
{
    public List<Material> ourPaints = new List<Material>();

    static private int paintIndex = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Paintable")
        {
            collision.collider.GetComponent<Renderer>().material = ourPaints[paintIndex];

            paintIndex = Random.Range(0, ourPaints.Count);

            //paintIndex++;

            //if(paintIndex == ourPaints.Count)
            //{
            //    paintIndex = 0;
            //}

        }
    }
}
