using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingCube : MonoBehaviour
{
    public WreckingBallResetButton resetButton;

    Vector3 startPosition;
    Quaternion startingRotation;
    AudioSource source;
    
    void Start()
    {
        startPosition = transform.position;
        startingRotation = transform.rotation;

        // creating a method that is listening for OnButtonPressed()
        resetButton.OnButtonPressed += ResetCube;

        source = GetComponent<AudioSource>();
    }
    
    public void ResetCube()
    {
        transform.position = startPosition;
        transform.rotation = startingRotation;

        // turn the cube on
        GetComponent<Renderer>().enabled = true;

        // stop the cube's movement!
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // reset score
        WreckingBallGameManager._instance.numberOfCubesDestroyed = 0;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.relativeVelocity.magnitude > 6)
        {
            Debug.Log("Impact velocity = " + collision.relativeVelocity.magnitude);
            source.volume = collision.relativeVelocity.magnitude / 4f;

            source.Play();
        }
    }

}
