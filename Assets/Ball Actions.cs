using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dribbling : MonoBehaviour
{
    private Vector3 position;
    private bool atFeet;
    private Vector3 shotDirection;
    public Rigidbody myRigidbody;
    public float ballSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (atFeet)
        {
            // Check if shoot button is pressed
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
            }
        }
    }

    // Dribbling
    // Connect ball to player when they touch
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Need the ball to follow the player after they collide
            // Cannot set the player as parent as this does not work in conjuction with the ball having its own physics
            // So add a joint between the two objects
            // First need to check if there is already a joint between ball and a player
            if (gameObject.GetComponent<FixedJoint>() == null)
            {
                FixedJoint fixedJoint = gameObject.AddComponent<FixedJoint>();
                fixedJoint.connectedBody = collision.rigidbody;
                // Stop collision between objects after they are connected
                // Stops objects from continuing to collide and creating more joints
                fixedJoint.enableCollision = false;
                atFeet = true;
            }
        }
    }

    // Shooting
    
    private void Shoot()
    {
        Debug.Log("Shooting");
        // Apply force to ball in direction player is looking at given time
        // direction player is looking is where the player is moving towards
        shotDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        myRigidbody.AddForce(shotDirection * ballSpeed);
        // Disconnect ball from player when shooting
        Object.Destroy(gameObject.GetComponent<FixedJoint>());
        atFeet = false;
    }
}
