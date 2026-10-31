using System.Collections;
using UnityEngine;
using Zenject;

public class SleepPresenter : MonoBehaviour
{
    [SerializeField] private SleepView _sleepView;
    [SerializeField, Min(1f)] private float _sleepDuration = 4f;
    [SerializeField] private DialoguePresenter _dialoguePresenter;
    [SerializeField] private PlayerLock _playerLock;

    private GameProgress _progress;

    private void OnEnable()
    {
        _dialoguePresenter.SleepRequested += PlaySleep;
    }

    private void OnDisable()
    {
        _dialoguePresenter.SleepRequested -= PlaySleep;
    }

    public void PlaySleep()
    {
        StartCoroutine(SleepRoutine());
    }

    private IEnumerator SleepRoutine()
    {
        _playerLock.Lock();

        _sleepView.Show();

        yield return new WaitForSeconds(_sleepDuration);

        _sleepView.Hide();

        _progress.CompleteSleep();

        _playerLock.Unlock();
    }

    [Inject]
    private void Construct(GameProgress gameProgress)
    {
        _progress = gameProgress;
    }
}