using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float speed;
    private Vector3 transformation;
    private Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Get vector to transform player by
        transformation = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        // Get rotation vector to rotate player by
        rotation = Quaternion.LookRotation(transformation);
    }

    // FixedUpdate is called whenever is needed per frame
    void FixedUpdate()
    {
        // Movement using Input.Getaxis
        myRigidbody.AddForce(transformation * speed);
        myRigidbody.rotation = rotation;
    }
}
