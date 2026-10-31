using UnityEngine;
using Zenject;

//получает нажатие е и определяет доступное действие
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private InteractionDetector _interactionDetector;

    private IPlayerControls _playerControls;

    private void OnEnable()
    {
        _playerControls.InteractPressed += OnInteractPressed;
    }

    private void OnDisable()
    {
        _playerControls.InteractPressed -= OnInteractPressed;
    }

    private void OnInteractPressed()
    {
        IInteractable interactable = _interactionDetector.CurrentInteractable;

        if (interactable != null)
            interactable.Interact();
    }

    [Inject]
    private void Construct(IPlayerControls playerControls)
    {
        _playerControls = playerControls;
    }
}