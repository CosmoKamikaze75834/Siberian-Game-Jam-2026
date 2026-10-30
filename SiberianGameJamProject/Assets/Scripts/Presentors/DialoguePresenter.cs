using UnityEngine;
using Zenject;

public class DialoguePresenter : MonoBehaviour
{
    [SerializeField] private BedInteraction _bedInteraction;
    [SerializeField] private DialogueView _dialogueView;

    private bool _isDialogueOpen;

    private IPlayerControls _controls;

    private void Awake()
    {
        _dialogueView.Hide();
    }

    private void OnEnable()
    {
        _bedInteraction.InteractionRequested += OnBedInteraction;
    }

    private void OnDisable()
    {
        _bedInteraction.InteractionRequested -= OnBedInteraction;
        _controls.InteractPressed -= CloseDialogue;
    }

    private void OnBedInteraction()
    {
        if (_isDialogueOpen)
            return;

        _dialogueView.Show("Сначала нужно установить все камеры.");
        _isDialogueOpen = true;

        _controls.InteractPressed += CloseDialogue;
    }

    private void CloseDialogue()
    {
        _dialogueView.Hide();
        _isDialogueOpen = false;

        _controls.InteractPressed -= CloseDialogue;
    }

    [Inject]
    private void Construct(IPlayerControls controls)
    {
        _controls = controls;
    }
}