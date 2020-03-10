using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPMJan : MonoBehaviour
{
    public GameObject testGameObject;
    public Transform location;
    public float moveSpeed = 10f;
    public float turnSpeed = 50f;
    public float jumpForce;
    public string mouseAxis;
    public bool isButtonPressed;

    public Vector3 handVelocity;
    private Vector3 previousPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        #region Translational movement
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);

            //Rigidbody rb = GetComponent<Rigidbody>();
            //rb.AddForce(Vector3.up * jumpForce);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.Translate(Vector3.down * Time.deltaTime * moveSpeed);
        }

        #endregion

        #region Rotation using mouse

        //transform.Rotate(Vector3.up * Input.GetAxis(mouseAxis) * turnSpeed);

        #endregion

        handVelocity = (this.transform.position - previousPosition) / Time.deltaTime;
        previousPosition = this.transform.position;

        if (Input.GetKeyDown(KeyCode.T))
        {
            isButtonPressed = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            isButtonPressed = false;
        }

        #region Rotation using keyboard
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.U))
        {
            transform.Rotate(Vector3.right * Time.deltaTime * turnSpeed);
        }
        if (Input.GetKey(KeyCode.N))
        {
            transform.Rotate(Vector3.left * Time.deltaTime * turnSpeed);
        }
        #endregion


    }
    
}