using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    
    private CharacterController characterController;
    private float interpolationFactor = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get movement vector from wasd
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector3 movementDirection = new Vector3(moveHorizontal, 0.0f, moveVertical);
        
        // Time.deltaTime used to make instantaneous movements act in a continuous ("smooth") way
        characterController.Move(Time.deltaTime * speed * movementDirection);
        
        // Character rotation in direction facing
        // Only if direction is not zero
        // Otherwise player will automatically rotate back
        if (movementDirection != Vector3.zero)
        {
            // Need a while loop to ensure interpolation is not greater than 1
            if (interpolationFactor < 1)
            {
                // forward is movementDirection, up is the vector (0, 1, 0)
                Quaternion targetRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                // Slerp (Spherical linear interpolation) - Used to rotate between two points in space (smoothly interpolate)
                // requires a starting rotation (the current rotation of the object)
                // a target rotation (as defined above based on movement)
                // an interpolation factor, t - value between 0 and 1 to create a smooth transition between the two
                // t = 0 is the start of the rotation
                // t = 1 is the end
                // So can think of t as a percentage of the rotation being completed
                interpolationFactor = rotationSpeed * Time.deltaTime;
                // Ensure it is less than or equal to one
                if (interpolationFactor > 1)
                {
                    interpolationFactor = 1;
                }
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, interpolationFactor);
            }
            else
            {
                // Reset factor as rotation has finished
                interpolationFactor = 0;
            }
        }
    }
}
