using UnityEngine;
using Zenject;

public class TreeCameraSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _mountPoint;

    private CameraPlacement _placement;

    public void Interact()
    {
        _placement.Place(_mountPoint.position);
    }

    [Inject]
    private void Construct(CameraPlacement placement)
    {
        _placement = placement;
    }
}