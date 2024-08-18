using UnityEngine;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;

public class MakeSoundWhenCollided : MonoBehaviour
{
    [SerializeField]
    private SourceAudio sourceAudio;
    [SerializeField]
    private AudioDataProperty clipName;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
        sourceAudio.Play(clipName.Key);
    }
}
