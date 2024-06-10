using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperMovement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float moveStrength;
    public KeyCode upKey;
    public KeyCode downKey;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {

    }

    // FixedUpdate is called whenever is needed per frame
    void FixedUpdate()
    {
        if (Input.GetKey(upKey)) {
            myRigidbody.velocity = Vector3.forward * moveStrength;
        }
        if (Input.GetKey(downKey))
        {
            myRigidbody.velocity = Vector3.back * moveStrength;
        }
    }
}
