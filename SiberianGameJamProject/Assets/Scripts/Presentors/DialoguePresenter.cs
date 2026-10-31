using System;
using UnityEngine;
using Zenject;

public class DialoguePresenter : MonoBehaviour
{
    [SerializeField] private Interaction[] _interactions;

    [SerializeField] private DialogueView _dialogueView;
    [SerializeField] private Dialogue _dialogue;

    private bool _isDialogueOpen;
    private bool _sleepAfterDialogue;

    private IPlayerControls _controls;
    private GameProgress _progress;

    public event Action SleepRequested;

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
                if (_progress.HasSlept)
                {
                    _dialogue.Show(DialogueId.AlreadySlept);
                }
                else if (_progress.AllCamerasPlaced)
                {
                    _sleepAfterDialogue = true;
                    _dialogue.Show(DialogueId.BedAvailable);
                }
                else
                {
                    _dialogue.Show(DialogueId.BedUnavailable);
                }
                break;

            case InteractionType.Laptop:
                if (_progress.AllCamerasCollected)
                {
                    Debug.Log("Ноут доступен");
                    return;
                }
                else
                    _dialogue.Show(DialogueId.LaptopUnavailable);
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

        if (_sleepAfterDialogue)
        {
            _sleepAfterDialogue = false;
            SleepRequested?.Invoke();
        }
    }

    [Inject]
    private void Construct(IPlayerControls controls, GameProgress gameProgress)
    {
        _controls = controls;
        _progress = gameProgress;
    }
}