using UnityEngine;
using Zenject;

//Первоначальная установка громкости и запуск музыки
public class AudioStartup : MonoBehaviour
{
    private AudioVolume _audioVolume;
    private AudioPlayer _audioPlayer;

    private void Start()
    {
        _audioVolume.SetMusicVolume(1f);
        _audioVolume.SetSFXVolume(1f);

        _audioPlayer.PlayMusic();
    }

    [Inject]
    private void Construct(AudioVolume audioVolume, AudioPlayer audioPlayer)
    {
        _audioVolume = audioVolume;
        _audioPlayer = audioPlayer;
    }
}