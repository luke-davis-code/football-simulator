using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Dribbling : MonoBehaviour
{
    private bool atFeet;
    private Vector3 lookDirection;
    public CharacterController ballController;
    public float shotSpeed;
    private GameObject current_player;
    
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
            // Ensure ball is always ahead of player
            if (new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) != Vector3.zero)
            {
                lookDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            }
            transform.position = current_player.transform.position + lookDirection;
        }
    }

    // Dribbling
    // Ball follows player after they collide
    private void OnControllerCollisionEnter(ControllerColliderHit collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Set current player to the player ball hits
            current_player = collision.gameObject;
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
        // ADDD IN FORCE TO SHOOT BALL HERE
        atFeet = false;
    }
}
