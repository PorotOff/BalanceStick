using UnityEngine;
using YG;

public class SaveBestScore : MonoBehaviour
{
    private ScoreCounter scoreCounter;

    private void Awake()
    {
        scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        GameOver.OnGameOver.AddListener(SaveBest);
    }
    private void OnDisable()
    {
        GameOver.OnGameOver.RemoveListener(SaveBest);
    }

    private void SaveBest()
    {
        if (ScoreCounter.Score > YandexGame.savesData.playerBestScore)
        {
            scoreCounter.enabled = false;

            ScoreCounter.playerBestScore = ScoreCounter.Score;
            YandexGame.savesData.playerBestScore = ScoreCounter.playerBestScore;

            YandexGame.NewLeaderboardScores("TableOfBallanciers", ScoreCounter.playerBestScore);
            YandexGame.SaveProgress();
        }
    }
}