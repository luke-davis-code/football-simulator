using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GKTeam2Movement : MonoBehaviour
{
    public Rigidbody myRigidbody;
    public float moveStrength;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            myRigidbody.velocity = Vector3.forward * moveStrength;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            myRigidbody.velocity = Vector3.back * moveStrength;
        }
    }
}
