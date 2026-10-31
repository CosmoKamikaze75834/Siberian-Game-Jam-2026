using System.Collections;
using UnityEngine;
using Zenject;

public class CameraPlacementDialoguePresenter : MonoBehaviour
{
    [SerializeField] private DialogueView _dialogueView;
    [SerializeField] private Dialogue _dualogue;

    private GameProgress _gameProgress;

    private void Start()
    {
        _gameProgress.AllCamerasPlacedEvent += OnAllCamerasPlaced;
    }

    private void OnDestroy()
    {
        if (_gameProgress != null)
            _gameProgress.AllCamerasPlacedEvent -= OnAllCamerasPlaced;
    }

    private void OnAllCamerasPlaced()
    {
        _dualogue.Show(DialogueId.AllCamerasPlaced);
        StartCoroutine(ShowTimeReplic());
    }

    private IEnumerator ShowTimeReplic()
    {
        yield return new WaitForSeconds(3);
        _dialogueView.Hide();
    }

    [Inject]
    private void Construct(GameProgress progress)
    {
        _gameProgress = progress;
    }
}