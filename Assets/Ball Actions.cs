using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Dribbling : MonoBehaviour
{
    private bool atFeet;
    private Vector3 lookDirection;
    public Rigidbody ballRigidbody;
    public float shotSpeed;
    private GameObject player;
    
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
            else
            {
                transform.position = player.transform.position + new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
        }
    }

    // Dribbling
    // Ball follows player after they collide
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Set current player to the player ball hits
            player = collision.gameObject;
            // Set dribbling flag to true
            atFeet = true;
        }
    }

    // Shooting
    // Force is applied to ball after shot button pressed
    private void Shoot()
    {
        Debug.Log("Shooting");
        // Apply force to ball in direction player is looking at given time
        // direction player is looking is where the player is moving towards
        lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        ballRigidbody.AddForce(lookDirection * shotSpeed);
        atFeet = false;
    }
}
