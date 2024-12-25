using UnityEngine;
using YG;

public class OnGameEntranceQuestLanguage : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.GetDataEvent += YandexGame.LanguageRequest;
    }
    private void OnDisable()
    {
        YandexGame.GetDataEvent -= YandexGame.LanguageRequest;
    }
}