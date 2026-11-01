using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class IntroWindow : Window
{
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private PlayerLock _playerLock;

    private GameProgress _progress;

    [Inject]
    private void Construct(GameProgress progress)
    {
        _progress = progress;
    }

    private void OnEnable()
    {
        _buttonContinue.onClick.AddListener(OnContinueClicked);
    }

    private void OnDisable()
    {
        _buttonContinue.onClick.RemoveListener(OnContinueClicked);
    }

    private void Start()
    {
        if (_progress.HasSeenIntro)
        {
            gameObject.SetActive(false);
            return;
        }

        _playerLock.Lock();
    }

    private void OnContinueClicked()
    {
        _progress.CompleteIntro();

        _playerLock.Unlock();
        gameObject.SetActive(false);
    }
}