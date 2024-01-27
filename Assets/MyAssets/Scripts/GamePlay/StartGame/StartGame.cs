using UnityEngine;
using YG;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private ScoreCounter scoreCounter;
    [SerializeField]
    private Animator rightButtonsAnimator;
    public static bool onGameStarted = false;

    [Header("start audio after game start")]
    [SerializeField]
    private SourceAudio backgroundMusic;
    [SerializeField]
    private AudioDataProperty clipName;

    private void Start() => YandexGame.LanguageRequest();

    private void OnEnable()
    {
        DetectTouchForStartGame.playerTouched += Play;
        YandexGame.GetDataEvent += YandexGame.LanguageRequest;
    }
    private void OnDisable()
    {
        DetectTouchForStartGame.playerTouched -= Play;
        YandexGame.GetDataEvent -= YandexGame.LanguageRequest;
    }
    public void Play()
    {
        backgroundMusic.Play(clipName.Key);
        rightButtonsAnimator.SetTrigger("PushRightButtons");
        scoreCounter.enabled = true;
    }
}
