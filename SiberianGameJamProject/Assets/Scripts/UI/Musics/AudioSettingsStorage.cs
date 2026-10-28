using System;
using UnityEngine;

public class AudioSettingsStorage
{
    private const string ParameterMusic = "MusicVolume";
    private const string ParameterMaster = "MasterVolume";
    private const string ParameterSFX = "SFXVolume";

    private const float InitialValue = 0.5f;

    public void SaveChanges()
    {
        PlayerPrefs.Save();
    }

    public void SaveVolume(AudioChannel audioChannel, float value)
    {
        PlayerPrefs.SetFloat(GetParameter(audioChannel), value);
    }

    public float LoadVolume(AudioChannel audioChannel)
    {
        return PlayerPrefs.GetFloat(GetParameter(audioChannel), InitialValue);
    }

    private string GetParameter(AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Music:
                return ParameterMusic;

            case AudioChannel.SFX:
                return ParameterSFX;

            case AudioChannel.Master:
                return ParameterMaster;

            default:
                throw new ArgumentOutOfRangeException(nameof(channel));
        }
    }
}