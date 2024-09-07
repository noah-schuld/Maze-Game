using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyMove : MonoBehaviour
{
    public float speed = 5f; // Adjust the speed as needed
    public float sensitivity = 2f; // Adjust the mouse look sensitivity as needed
    private Transform playerBody; // Reference to the player's body to rotate along with the camera
    new private Rigidbody rigidbody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerBody = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Player movement
        MovePlayer();

        // Camera mouse look
        LookWithMouse();
    }

    void MovePlayer()
    {
        // Get input from the user
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Move the player
        rigidbody.velocity = playerBody.localToWorldMatrix * movement * speed;
    }

    void LookWithMouse()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate the camera based on mouse input
        xRotation += mouseX;

        transform.localRotation = Quaternion.Euler(0, xRotation, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}