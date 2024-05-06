using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class UnderwaterSwimmingController : MonoBehaviour
{
    public float swimSpeed = 5f;
    public float gravity = 9.81f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if underwater (you may need to adjust this based on your environment)
        if (transform.position.y < 0)
        {
            // Player input for movement
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            // Calculate movement direction based on input
            Vector3 inputVector = new Vector3(horizontalInput, 0f, verticalInput);
            inputVector.Normalize();

            // Convert input vector to world space
            moveDirection = transform.TransformDirection(inputVector);

            // Apply swimming speed
            moveDirection *= swimSpeed;

            // Apply gravity
            moveDirection.y -= gravity * Time.deltaTime;

            // Move the character controller
            characterController.Move(moveDirection * Time.deltaTime);
        }
    }
}