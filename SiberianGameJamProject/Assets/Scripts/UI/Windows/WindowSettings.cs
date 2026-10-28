using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;
using Zenject;

public class WindowSettings : Window
{
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    [SerializeField] private Slider _masterVolumeSlider;

    [SerializeField] private Button _buttonBack;

    [SerializeField] private TMP_Dropdown _languageDropdown;

    private AudioVolume _audioVolume;
    private AudioSettingsStorage _settingsStorage;

    public event Action MainMenuRequested;

    private void Start()
    {
        Close();

        _musicVolumeSlider.SetValueWithoutNotify(_settingsStorage.LoadVolume(AudioChannel.Music));
        _sfxVolumeSlider.SetValueWithoutNotify(_settingsStorage.LoadVolume(AudioChannel.SFX));
        _masterVolumeSlider.SetValueWithoutNotify(_settingsStorage.LoadVolume(AudioChannel.Master));

        Locale currentLocale = LocalizationSettings.SelectedLocale;

        int index = currentLocale != null &&
                    currentLocale.Identifier.Code == "en" ? 1 : 0;

        _languageDropdown.SetValueWithoutNotify(index);
    }

    private void OnEnable()
    {
        _musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);

        _buttonBack.onClick.AddListener(OnClickBack);

        _languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
    }

    private void OnDisable()
    {
        _musicVolumeSlider.onValueChanged.RemoveListener(OnMusicVolumeChanged);
        _sfxVolumeSlider.onValueChanged.RemoveListener(OnSFXVolumeChanged);
        _masterVolumeSlider.onValueChanged.RemoveListener(OnMasterVolumeChanged);

        _buttonBack.onClick.RemoveListener(OnClickBack);

        _languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
    }

    private void OnMusicVolumeChanged(float value)
    {
        _audioVolume.SetMusicVolume(value);
        _settingsStorage.SaveVolume(AudioChannel.Music, value);
    }

    private void OnSFXVolumeChanged(float value)
    {
        _audioVolume.SetSFXVolume(value);
        _settingsStorage.SaveVolume(AudioChannel.SFX, value);
    }

    private void OnMasterVolumeChanged(float value)
    {
        _audioVolume.SetMasterVolume(value);
        _settingsStorage.SaveVolume(AudioChannel.Master, value);
    }

    private void OnClickBack()
    {
        MainMenuRequested?.Invoke();
        _settingsStorage.SaveChanges();
    }

    private void OnLanguageChanged(int index)
    {
        string languageCode = index == 0 ? "ru" : "en";

        Locale locale = LocalizationSettings.AvailableLocales.GetLocale(
            new LocaleIdentifier(languageCode));

        if (locale == null)
        {
            Debug.LogWarning($"Locale not found: {languageCode}");
            return;
        }

        LocalizationSettings.SelectedLocale = locale;
    }

    [Inject]
    private void Construct(AudioVolume audioVolume, AudioSettingsStorage settingsStorage)
    {
        _audioVolume = audioVolume;
        _settingsStorage = settingsStorage;
    }
}