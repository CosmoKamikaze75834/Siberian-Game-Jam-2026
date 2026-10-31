using UnityEngine;
using Zenject;

public class TreeCameraSpot : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _mountPoint;

    private CameraPlacement _placement;
    private GameProgress _progress;

    public void Interact()
    {
        Vector3 position = _mountPoint.position;

        if (_progress.HasSlept)
        {
            _placement.TryCollect(position);
            return;
        }

        _placement.Place(position);
    }

    [Inject]
    private void Construct(CameraPlacement placement, GameProgress progress)
    {
        _placement = placement;
        _progress = progress;
    }
}