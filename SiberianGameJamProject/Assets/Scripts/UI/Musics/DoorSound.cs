using UnityEngine;
using UnityEngine.Audio;

public class DoorSound : MonoBehaviour
{
    [SerializeField] private AudioClip _doorClip;
    [SerializeField] private AudioMixerGroup _sfxGroup;

    public void Play()
    {
        if (_doorClip == null)
            return;

        GameObject soundObject = new GameObject("DoorSound");

        DontDestroyOnLoad(soundObject);

        AudioSource source = soundObject.AddComponent<AudioSource>();

        source.playOnAwake = false;
        source.spatialBlend = 0f;
        source.outputAudioMixerGroup = _sfxGroup;

        source.PlayOneShot(_doorClip);

        Destroy(soundObject, _doorClip.length + 0.1f);
    }
}