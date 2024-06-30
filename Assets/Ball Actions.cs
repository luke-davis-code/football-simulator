using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dribbling : MonoBehaviour
{
    private Vector3 position;
    private bool hasBall;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBall)
        {
            // Check if shoot button is pressed
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
            }
        }
    }

    // Dribbling
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Need the ball to follow the player after they collide
            // Cannot set the player as parent as this does not work in conjuction with the ball having its own physics
            // So add a joint between the two objects
            FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
            fixedJoint.connectedBody = collision.rigidbody;
            // Stop collision between objects after they are connected
            // Stops objects from continuing to collide and creating more joints
            fixedJoint.enableCollision = false;
            hasBall = true;
        }
    }

    private void Shoot()
    {
        Debug.Log("Shooting");
        hasBall = false;
    }
}
