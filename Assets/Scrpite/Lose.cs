using UnityEngine;
using UnityEngine.SceneManagement;
public class Lose : MonoBehaviour
{
    public void RestartLeveButton()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
    public void QuitGameButton()
    {
        Application.Quit();
        Debug.Log("Game is quitting");
    }

}
