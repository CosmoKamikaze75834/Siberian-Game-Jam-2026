using UnityEngine;
using Zenject;

//Первоначальная установка громкости и запуск музыки
public class AudioStartup : MonoBehaviour
{
    private AudioVolume _audioVolume;
    private AudioPlayer _audioPlayer;
    private AudioSettingsStorage _settingsStorage;

    private void Start()
    {
        float musicVolume = _settingsStorage.LoadVolume(AudioChannel.Music);
        _audioVolume.SetMusicVolume(musicVolume);

        float sfxVolume = _settingsStorage.LoadVolume(AudioChannel.SFX);
        _audioVolume.SetSFXVolume(sfxVolume);

        float masterVolume = _settingsStorage.LoadVolume(AudioChannel.Master);
        _audioVolume.SetMasterVolume(masterVolume);

        _audioPlayer.PlayMusic();
    }

    [Inject]
    private void Construct(AudioVolume audioVolume, AudioPlayer audioPlayer, AudioSettingsStorage settingsStorage)
    {
        _audioVolume = audioVolume;
        _audioPlayer = audioPlayer;
        _settingsStorage = settingsStorage;
    }
}