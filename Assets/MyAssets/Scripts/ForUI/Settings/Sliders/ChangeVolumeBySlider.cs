using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class ChangeVolumeBySlider : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    [SerializeField] private string mixerGroupName;
    private Slider volumeSlider;

    private void Start()
    {
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = PlayerPrefs.GetFloat($"valueOf{mixerGroupName}");
    }

    public void ChangeVolume()
    {
        mixer.SetFloat(mixerGroupName, volumeSlider.value);
        PlayerPrefs.SetFloat($"valueOf{mixerGroupName}", volumeSlider.value);
    }
}
