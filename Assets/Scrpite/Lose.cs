/*
* Author: LiuBingxun
* Date: 14/6/2025
* Description: die alr restart level or quit game
*/

using UnityEngine;
using UnityEngine.SceneManagement;

public class Lose : MonoBehaviour
{
    // Called when the Restart button is pressed; reloads the current scene
    public void RestartLeveButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex; // Get current scene index
        SceneManager.LoadScene(currentScene); // Reload the scene
    }

    // Called when the Quit button is pressed; quits the game
    public void QuitGameButton()
    {
        Application.Quit(); // Quit the application
        Debug.Log("Game is quitting"); // Log for debugging (won't show in build)
    }
}