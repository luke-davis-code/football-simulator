using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.iOS;
using UnityEngine.Serialization;

public class PlayerActions : MonoBehaviour
{
    public CharacterController myController;
    public Animator animator;
    public float movementSpeed;
    public float rotationSpeed;
    private float currentSpeed;
    private Vector3 transformation;
    private Vector3 eulerAngleVelocity;
    private bool sprinting = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        // Movement code
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
        myController.Move(Time.deltaTime * movementSpeed * transformation);
        // Allow sprint when right trigger is pressed
        if (Gamepad.current.rightTrigger.wasPressedThisFrame)
        {
            movementSpeed = movementSpeed * 1.50f;
            animator.SetBool("Sprint", true);
        }
        // Change back to normal speed when right trigger released
        if (Gamepad.current.rightTrigger.wasReleasedThisFrame)
        {
            movementSpeed = movementSpeed / 1.5f;
            // ADD A SPRINT MODIFIER
            animator.SetBool("Sprint", false);
        }
        
        // Animation Code
        // Set the current speed number to keep track of speed for animator to use
        // Use the absolute values of the joystick inputs to do this
        currentSpeed = Mathf.Abs(transformation.x) + Mathf.Abs(transformation.z);
        Debug.Log(currentSpeed);
        // Joystic input has values from -1 to 1 so with absolute 0 to 1
        // For values at 0 play idle animation
        // For values between 0 to 0.5 play walking animation
        // For values greater than 0.5 play running animation
        
        // If sprint button is pressed at any time play sprint animation
        if (sprinting)
        {
            animator.SetBool("Sprint", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
        }
        else if (currentSpeed > 0f && currentSpeed < 0.5f)
        {
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", false);
        }
        else if (currentSpeed >= 0.5f)
        {
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", true);
            animator.SetBool("Idle", false);
        }
        else
        {
            animator.SetBool("Sprint", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Run", false);
            animator.SetBool("Idle", true);
        }
    }
}
