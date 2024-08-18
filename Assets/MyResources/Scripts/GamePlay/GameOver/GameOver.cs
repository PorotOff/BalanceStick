using UnityEngine;
using YG;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class GameOver : MonoBehaviour
{
    private Animator gameOverPanelAnimation;
    private SourceAudio openGameOverPanelSound;
    [SerializeField]
    private ScoreCounter scoreCounter;
    [SerializeField]
    private AudioDataProperty clipName;
    [SerializeField]
    private SourceAudio backgroundMusic;

    public static bool IsGameOver = false;

    private void Awake()
    {
        gameOverPanelAnimation = GetComponent<Animator>();
        openGameOverPanelSound = GetComponent<SourceAudio>();
    }

    private void OnEnable() => DetectEnemyTouch.EnemyTouched += LaunchGameOver;
    private void OnDisable() => DetectEnemyTouch.EnemyTouched -= LaunchGameOver;

    private void LaunchGameOver()
    {
        if (!IsGameOver)
        {
            backgroundMusic.Stop();
            openGameOverPanelSound.Play(clipName.Key);
            gameOverPanelAnimation.SetTrigger("NowIsGameOver");
            scoreCounter.enabled = false;

            if (ScoreCounter.Score > YandexGame.savesData.playerBestScore)
            {
                SaveBestScore();
            }

            IsGameOver = true;
        }
    }
    private void SaveBestScore()
    {
        ScoreCounter.playerBestScore = ScoreCounter.Score;
        YandexGame.savesData.playerBestScore = ScoreCounter.playerBestScore;
        YandexGame.NewLeaderboardScores("TableOfBallanciers", ScoreCounter.playerBestScore);
        YandexGame.SaveProgress();
    }
}
