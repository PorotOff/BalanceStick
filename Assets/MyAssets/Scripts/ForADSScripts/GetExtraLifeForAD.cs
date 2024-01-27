using System;
using UnityEngine;
using YG;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class GetExtraLifeForAD : MonoBehaviour
{
    [SerializeField] private YandexGame sdk;
    [SerializeField] private ScoreCounter scoreCounterScript;
    [SerializeField] private Animator gameOverPanelAnimator;
    [Header("Audio")]
    [SerializeField] private SourceAudio backgroundMusic;
    [SerializeField] private AudioDataProperty backgroundMusicClipName;
    [SerializeField] private SourceAudio gameOverPanelClosedSound;
    [SerializeField] private AudioDataProperty gameOverPanelClosedSoundClipName;

    public static Action OnReceivedExtraLife;

    private bool lookingAD = false;

    public void ADButton()
    {
        lookingAD = true;
        sdk._RewardedShow(1);
    }
    public void GiveReward()
    {
        if (lookingAD)
        {
            gameOverPanelAnimator.SetTrigger("GettedExtraLife");
            backgroundMusic.Play(backgroundMusicClipName.Key);
            gameOverPanelClosedSound.Play(gameOverPanelClosedSoundClipName.Key);

            scoreCounterScript.enabled = true;
            GameOver.IsGameOver = false;
            OnReceivedExtraLife?.Invoke();

            lookingAD = false;
        }
    }
}
