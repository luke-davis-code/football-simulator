using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerActions : MonoBehaviour
{
    public CharacterController myController;
    public float speed;
    public float ballSpeed;
    public float rotationSpeed;
    private Vector3 transformation;
    private Vector3 eulerAngleVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
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
        myController.Move(Time.deltaTime * speed * transformation);
        // Allow sprint when right trigger is pressed
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            speed = speed * 1.50f;
        }
        // Change back to normal speed when right trigger released
        if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
        {
            speed = speed / 1.5f;
        }
    }
}
