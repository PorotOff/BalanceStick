using UnityEngine;

public class ControlBackgroundMusic : MonoBehaviour, IMusicControlable
{
    private AudioSource backgroundMusicAudioSource;

    private void Awake()
    {
        backgroundMusicAudioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        StartGame.OnGameStarted.AddListener(Play);
    }
    private void OnDisable()
    {
        StartGame.OnGameStarted.RemoveListener(Play);
    }

    public void Play()
    {
        backgroundMusicAudioSource.Play();
    }

    public void Pause()
    {
        backgroundMusicAudioSource.Pause();
    }

    public void Stop()
    {
        backgroundMusicAudioSource.Stop();
    }
}