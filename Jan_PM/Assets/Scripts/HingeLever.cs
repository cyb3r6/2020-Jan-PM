using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeLever : MonoBehaviour
{
    public HingeJoint myJoint;  

    public float JointAngle()
    {
        float angle = myJoint.angle / myJoint.limits.max;
        return angle;
    }
}
