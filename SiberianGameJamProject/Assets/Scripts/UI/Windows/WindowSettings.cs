using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowSettings : Window
{
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private Slider _masterVolumeSlider;

    private AudioVolume _audioVolume;

    private void OnEnable()
    {
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
    }

    private void OnDisable()
    {
        _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);
    }

    private void OnMusicVolumeChanged(float value)
    {
        _audioVolume.SetMusicVolume(value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        _audioVolume.SetSFXVolume(value);
    }

    private void OnMasterVolumeChanged(float value)
    {
        _audioVolume.SetMasterVolume(value);
    }

    [Inject]
    private void Construct(AudioVolume audioVolume)
    {
        _audioVolume = audioVolume;
    }
}