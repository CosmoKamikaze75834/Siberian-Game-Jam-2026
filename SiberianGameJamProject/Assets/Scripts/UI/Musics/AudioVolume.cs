using UnityEngine;
using UnityEngine.Audio;

//изменение громкости звуков
public class AudioVolume : MonoBehaviour
{
    private const float MinLinearVolume = 0.0001f;
    private const float DecibelMultiplier = 20f;
    private const string MusicVolumeParameter = "MusicVolume";
    private const string SFXVolumeParameter = "SFXVolume";
    private const string MasterVolumeParameter = "MasterVolume";

    [SerializeField] private AudioMixer _audioMixer;

    public void SetMusicVolume(float volume)
    {
        SetVolume(MusicVolumeParameter, volume);
    }

    public void SetSFXVolume(float volume)
    {
        SetVolume(SFXVolumeParameter, volume);
    }

    public void SetMasterVolume(float volume)
    {
        SetVolume(MasterVolumeParameter, volume);
    }

    private void SetVolume(string parameter, float volume)
    {
        float decibels = Mathf.Log10(Mathf.Max(volume, MinLinearVolume)) * DecibelMultiplier;
        _audioMixer.SetFloat(parameter, decibels);
    }
}