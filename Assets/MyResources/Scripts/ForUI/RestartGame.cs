using UnityEngine.SceneManagement;
using UnityEngine;

public class RestartGame : MonoBehaviour
{
    public void RestartScene()
    {
        GameOver.IsGameOver = false;
        StartGame.onGameStarted = false;
        SceneManager.LoadScene(0);
    }
}