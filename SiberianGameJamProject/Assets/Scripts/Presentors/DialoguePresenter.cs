using UnityEngine;
using Zenject;

public class DialoguePresenter : MonoBehaviour
{
    [SerializeField] private Interaction[] _interactions;

    [SerializeField] private DialogueView _dialogueView;
    [SerializeField] private Dialogue _dualogue;

    private bool _isDialogueOpen;

    private IPlayerControls _controls;

    private void Awake()
    {
        _dialogueView.Hide();
    }

    private void OnEnable()
    {
        foreach (Interaction interaction in _interactions)
        {
            if (interaction != null)
                interaction.InteractionRequested += OnInteraction;
        }
    }

    private void OnDisable()
    {
        foreach (Interaction interaction in _interactions)
        {
            if (interaction != null)
                interaction.InteractionRequested -= OnInteraction;
        }

        _controls.InteractPressed -= CloseDialogue;
    }

    private void OnInteraction(InteractionType interactionType)
    {
        if (_isDialogueOpen)
            return;

        switch (interactionType)
        {
            case InteractionType.Bed:
                _dualogue.Show(DialogueId.BedUnavailable);
                break;

            case InteractionType.Laptop:
                _dualogue.Show(DialogueId.LaptopUnavailable);
                break;
        }

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