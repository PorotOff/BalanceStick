using UnityEngine;

public class EnableScoreCounter : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        StartGame.OnGameStarted.AddListener(Enable);
    }
    private void OnDisable()
    {
        StartGame.OnGameStarted.RemoveListener(Enable);
    }

    private void Enable()
    {
        scoreCounter.enabled = true;
    }
}