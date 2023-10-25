using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    // This method is called when the "Start Game" button in the UI is clicked.
    public void StartGame()
    {
        Debug.Log("Click"); // Output a debug message to the console to indicate that the button was clicked.
        SceneManager.LoadScene("Game"); // Load the scene named "Game" using Unity's SceneManager. 
    }
}