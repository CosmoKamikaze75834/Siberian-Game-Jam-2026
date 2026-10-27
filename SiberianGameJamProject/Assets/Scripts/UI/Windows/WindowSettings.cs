using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowSettings : Window
{
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private Slider _masterVolumeSlider;

    [SerializeField] private Button _buttonBack;

    private AudioVolume _audioVolume;

    public event Action MainMenuRequested;

    private void Start()
    {
        Close();
    }

    private void OnEnable()
    {
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);

        _buttonBack.onClick.AddListener(OnClickBack);
    }

    private void OnDisable()
    {
        _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);

        _buttonBack.onClick.RemoveListener(OnClickBack);
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

    private void OnClickBack()
    {
        MainMenuRequested?.Invoke();
    }

    [Inject]
    private void Construct(AudioVolume audioVolume)
    {
        _audioVolume = audioVolume;
    }
}