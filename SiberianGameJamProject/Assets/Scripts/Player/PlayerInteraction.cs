using UnityEngine;
using Zenject;

//получает нажатие е и определяет доступное действие
public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private CameraPlacement _cameraPlacement;

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
        _cameraPlacement.Place();
    }

    [Inject]
    private void Construct(IPlayerControls playerControls)
    {
        _playerControls = playerControls;
    }
}