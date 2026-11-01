using UnityEngine;
using Zenject;

public class PlayerFootsteps : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip[] _footsteps;
    [SerializeField, Min(0.1f)] private float _stepInterval = 0.4f;

    private IPlayerControls _controls;

    private float _timer;
    private int _lastStepIndex = -1;

    [Inject]
    private void Construct(IPlayerControls controls)
    {
        _controls = controls;
    }

    private void Update()
    {
        if (_controls.MoveDirection.sqrMagnitude < 0.01f)
        {
            _timer = 0f;
            return;
        }

        _timer -= Time.deltaTime;

        if (_timer > 0f)
            return;

        PlayFootstep();
        _timer = _stepInterval;
    }

    private void PlayFootstep()
    {
        if (_audioSource == null || _footsteps == null || _footsteps.Length == 0)
            return;

        int index;

        if (_footsteps.Length == 1 || _lastStepIndex < 0)
        {
            index = Random.Range(0, _footsteps.Length);
        }
        else
        {
            index = Random.Range(0, _footsteps.Length - 1);

            if (index >= _lastStepIndex)
                index++;
        }

        AudioClip clip = _footsteps[index];

        if (clip == null)
            return;

        _audioSource.PlayOneShot(clip);
        _lastStepIndex = index;
    }
}