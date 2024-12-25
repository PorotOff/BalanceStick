using UnityEngine;

public class ActivateGameOverPanel : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;

    private void OnEnable()
    {
        GameOver.OnGameOver.AddListener(Activate);
    }
    private void OnDisable()
    {
        GameOver.OnGameOver.RemoveListener(Activate);
    }

    private void Activate()
    {
        gameOverPanel.SetActive(true);
    }
}