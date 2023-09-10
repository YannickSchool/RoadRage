using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D carRigidbody;
    public float baseMoveSpeed = 50.0f; // Base movement speed
    public float maxSpeed = 100.0f; // Maximum speed limit
    private bool isBoosting = false; // Flag to track if boosting is active
    private float originalMoveSpeed; // Store the original move speed
    private float moveDirection; // Input direction for movement

    // Start is called before the first frame update
    void Start()
    {
        carRigidbody = GetComponent<Rigidbody2D>();
        originalMoveSpeed = baseMoveSpeed; // Store the original move speed
    }

    // Update is called once per frame
    void Update()
    {
        // Detect spacebar press to activate boost
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Boost();
        }
        // Detect spacebar release to deactivate boost
        if (Input.GetKeyUp(KeyCode.Space))
        {
            ResetBoost();
        }

        moveDirection = Input.GetAxisRaw("Horizontal");
    }

    public void FixedUpdate()
    {
        // Calculate the target position based on input and time
        Vector2 targetPosition = carRigidbody.position + new Vector2(moveDirection * baseMoveSpeed * Time.fixedDeltaTime, 0);

        // Reset the velocity to zero before applying new velocity
        carRigidbody.velocity = Vector2.zero;

        // Apply the new velocity based on input and moveSpeed
        carRigidbody.velocity = new Vector2(moveDirection * Time.fixedTime * baseMoveSpeed, 0);

        // Clamp the velocity to the specified maximum speed
        carRigidbody.velocity = new Vector2(Mathf.Clamp(carRigidbody.velocity.x, -maxSpeed, maxSpeed), carRigidbody.velocity.y);
    }

    private void Boost()
    {
        Debug.Log("Boost function called");
        // Increase baseMoveSpeed when boosting
        baseMoveSpeed *= 2;
        isBoosting = true;
    }

    private void ResetBoost()
    {
        Debug.Log("Reset function called");
        // Reset baseMoveSpeed to its original value when boost is reset
        baseMoveSpeed = originalMoveSpeed;
        isBoosting = false;
    }
}