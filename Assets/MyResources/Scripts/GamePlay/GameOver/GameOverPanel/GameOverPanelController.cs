using UnityEngine;

public class GameOverPanelController : MonoBehaviour
{
    private Animator gameOverPanelAnimator;

    private void Awake()
    {
        gameOverPanelAnimator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        GameOver.OnGameOver.AddListener(OpenGameOverPanel);
    }
    private void OnDisable()
    {
        GameOver.OnGameOver.RemoveListener(OpenGameOverPanel);
    }

    private void OpenGameOverPanel()
    {
        gameOverPanelAnimator.SetTrigger("NowIsGameOver");
    }
}