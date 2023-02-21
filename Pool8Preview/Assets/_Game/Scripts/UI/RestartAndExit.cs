using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartAndExit : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exit");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("AngryBots");
        Time.timeScale = 1f;
    }
}
