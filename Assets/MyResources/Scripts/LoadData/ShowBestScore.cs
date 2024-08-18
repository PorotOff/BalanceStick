using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShowBestScore : MonoBehaviour
{
    private Text scoreText;

    private void Awake() => scoreText = GetComponent<Text>();
    private void Start() => Output(YandexGame.EnvironmentData.language);

    private void OnEnable() => YandexGame.SwitchLangEvent += Output;
    private void OnDisable() => YandexGame.SwitchLangEvent -= Output;

    private void Output(string language)
    {
        scoreText.text = $"BEST\n{YandexGame.savesData.playerBestScore}";
        if (language == "ru") scoreText.text = $"ксвьхи\n{YandexGame.savesData.playerBestScore}";
    }
}
