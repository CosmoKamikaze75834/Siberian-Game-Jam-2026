using UnityEngine;
using Zenject;

public class DialoguePresenter : MonoBehaviour
{
    [SerializeField] private Interaction[] _interactions;

    [SerializeField] private DialogueView _dialogueView;

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
                ShowBed();
                break;

            case InteractionType.Laptop:
                ShowLaptop();
                break;
        }

        _isDialogueOpen = true;

        _controls.InteractPressed += CloseDialogue;
    }

    public void ShowBed()
    {
        _dialogueView.Show("Сначала нужно установить все камеры.");
    }

    public void ShowLaptop()
    {
        _dialogueView.Show("У меня ещё нет плёнок для просмотра");
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