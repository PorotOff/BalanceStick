using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine.Events;

public class GameOver : MonoBehaviour
{
    public static UnityEvent OnGameOver = new UnityEvent();
    
    [SerializeField] private AudioDataProperty clipName;
    [SerializeField] private SourceAudio backgroundMusic;

    public static bool IsGameOver = false;

    private void OnEnable()
    {
        DetectEnemyTouch.OnEnemyTouched.AddListener(LaunchGameOver);
    }
    private void OnDisable()
    {
        DetectEnemyTouch.OnEnemyTouched.RemoveListener(LaunchGameOver);
    }

    private void LaunchGameOver()
    {
        OnGameOver?.Invoke();

        if (!IsGameOver)
        {
            backgroundMusic.Stop();

            IsGameOver = true;
        }
    }
}
