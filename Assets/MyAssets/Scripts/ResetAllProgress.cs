using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class ResetAllProgress : MonoBehaviour
{
    public void DeleteAllPlayerData()
    {

        YandexGame.ResetSaveProgress();
        PlayerPrefs.DeleteAll();
        YandexGame.savesData.playerBestScore = 0;
        YandexGame.NewLeaderboardScores("TableOfBallanciers", 0);
        YandexGame.SaveProgress();
        DontStartGameIfPlayerInSettings.playerInSettings = false;
        SceneManager.LoadScene(0);
    }
}