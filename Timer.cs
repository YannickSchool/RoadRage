using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimeText; // Reference to the TextMeshPro text component for displaying time.
    public float elapsedTime = 0.0f; // Elapsed time in seconds.

    // Update is called once per frame.
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            elapsedTime += 100; // If the space key is pressed, add 100 to the elapsed time.
        }
        else
        {
            elapsedTime += 1; // If the space key is not pressed, add 1 to the elapsed time.
        }

        float displayTime = elapsedTime; // Convert elapsed time to a float for display purposes.

        // Update the time text component with the integer representation of elapsed time.
        TimeText.text = ((int)displayTime).ToString();

        // Set the text alignment to center.
        TimeText.alignment = TextAlignmentOptions.Center;
    }

    void OnDisable()
    {
        // Save the elapsed time to PlayerPrefs when the script is disabled or the GameObject is destroyed.
        PlayerPrefs.SetFloat("elapsedTime", elapsedTime);
    }
}