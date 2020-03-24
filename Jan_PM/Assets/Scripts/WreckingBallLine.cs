using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallLine : MonoBehaviour
{
    public LineRenderer lineChain;
    public Transform angryJoeTransform;
    
    void Update()
    {
        lineChain.SetPosition(0, this.transform.position);
        lineChain.SetPosition(1, angryJoeTransform.position);
    }
}
