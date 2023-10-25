using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public TMPro.TMP_Text HighScoreText; // Reference to the TextMeshPro text component for displaying the high score.

    public float score; // The player's current score.
    public float pop; // Variable to store the player's previous best score retrieved from PlayerPrefs.

    void OnEnable()
    {
        // Load the player's previous best score from PlayerPrefs.
        pop = PlayerPrefs.GetInt("elapsedTime");
    }

    public void Update()
    {
        // Check if the current score is less than the previous best score (pop).
        if (score < pop)
        {
            Debug.Log("7070"); // Output a debug message to indicate the condition was met.
            score = pop; // Update the current score with the previous best score.
        }

        float erocs = score; // Convert the score to a float for display purposes.

        // Update the high score text with the integer representation of the current score.
        HighScoreText.text = ((int)erocs).ToString();

        // Set the text alignment to center.
        HighScoreText.alignment = TMPro.TextAlignmentOptions.Center;
    }
}