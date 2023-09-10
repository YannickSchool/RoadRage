using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    public TMPro.TMP_Text speedLabel;

    // Current custom speed
    private int currentCustomSpeed = 0;

    // Rate of increase in custom speed per second
    public float customSpeedIncreaseRate = 1.0f;

    // Maximum custom speed allowed
    public float maxCustomSpeed = 50.0f;

    // Variable to control boost activation
    private int boostControl = 0;

    // Flag to indicate if custom speed is capped
    public bool isCustomSpeedCapped = false;

    // Timer to track the time since the last increase in custom speed
    private float timeSinceLastIncrease = 0.0f;

    void Update() 
    {
        // Update the timer
        timeSinceLastIncrease += Time.deltaTime;

        // Check if custom speed is greater than or equal to the maximum allowed custom speed
        // and boost control flag is not set
        if (currentCustomSpeed >= maxCustomSpeed && boostControl == 0)
        {
            isCustomSpeedCapped = true;
        }

        // Increase custom speed based on the specified rate, but only if it's not capped
        if (timeSinceLastIncrease >= 1.0f / customSpeedIncreaseRate && !isCustomSpeedCapped && currentCustomSpeed < 60.0f)
        {
            currentCustomSpeed += 1;
            timeSinceLastIncrease = 0.0f; // Reset the timer
        }

        // Display the current custom speed
        float speed = currentCustomSpeed;
        speedLabel.text = ((int)speed).ToString();
        speedLabel.alignment = TMPro.TextAlignmentOptions.Center;

        // Check for boost (e.g., space key) press to increase custom speed by 10 and set boost control flag
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentCustomSpeed += 10;
            boostControl = 1;
        }

        // Check for spacebar release to decrease custom speed by 10 and reset boost control flag
        if (Input.GetKeyUp(KeyCode.Space))
        {
            currentCustomSpeed -= 10;
            boostControl = 0;
        }

        // Ensure custom speed is not negative
        currentCustomSpeed = Mathf.Max(currentCustomSpeed, 0);
    }
}