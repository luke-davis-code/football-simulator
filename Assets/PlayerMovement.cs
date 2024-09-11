using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CFMovement : MonoBehaviour
{
    public CharacterController myController;
    public float speed;
    public float ballSpeed;
    public float rotationSpeed;
    private string team;
    private string opponent;
    private Vector3 transformation;
    private Vector3 eulerAngleVelocity;
    private bool hasBall;
    

    // Start is called before the first frame update
    void Start()
    {
        hasBall = false;
        team = "Home";
        opponent = "Away";
    }

    // Update is called once per frame
    private void Update()
    {
        // Get vector to transform player by
        transformation = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // Get rotation vector to rotate player by
        eulerAngleVelocity = new Vector3(0, rotationSpeed, 0);
        // Apply rotation in update as does not use physics
        // If the rotation is zero then do not apply as this prevents the rotation being smooth
        if (transformation != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(transformation);
        }
        myController.Move(transformation * speed * Time.deltaTime);
        if (hasBall)
        {
            if (Input.GetButtonDown("Shoot"))
            {
                Shoot();
            }
        }
    }

    private void OnTriggerEnter(Collider objectHit)
    {
        if (objectHit.gameObject.tag == "Ball")
        {
            // Set balls transfrom parent to this player transform
            objectHit.transform.parent = this.transform;
            // Set dribbling flag to true
            hasBall = true;
        }
    }

    private void Shoot()
    {
        // Ball should always be child 1
        GameObject ball = this.transform.Find("Ball").gameObject;
        GameObject goal = GameObject.Find(opponent + "/Goal");
        // Remove ball as child of player
        ball.transform.parent = null;
        // Set dribbling flag to false
        hasBall = false;
        // Ball moves towards opponents goal
        // MAYBE MOVE THIS INTO UPDATE AS MOVEMENT IS INSTANTANEOUS AT MOMENT
        ball.transform.position = Vector3.MoveTowards(ball.transform.position, goal.transform.position, ballSpeed);
    }
}
