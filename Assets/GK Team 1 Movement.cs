using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float diveStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) {
            myRigidbody.velocity = Vector3.forward * diveStrength;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            myRigidbody.velocity = Vector3.back * diveStrength;
        }
    }
}
