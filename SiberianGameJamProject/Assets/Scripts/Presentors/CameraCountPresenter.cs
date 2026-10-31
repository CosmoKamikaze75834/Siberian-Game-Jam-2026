using UnityEngine;

public class CameraCountPresenter : MonoBehaviour
{
    [SerializeField] private CameraCountView _cameraCountView;
    [SerializeField] private CameraPlacement _placement;

    private void Start()
    {
        OnCameraCountChanged(_placement.RemainingCameraCount);
    }

    private void OnEnable()
    {
        _placement.AmountChanged += OnCameraCountChanged;
    }

    private void OnDisable()
    {
        _placement.AmountChanged -= OnCameraCountChanged;
    }

    private void OnCameraCountChanged(int count)
    {
        _cameraCountView.Display(count, _placement.MaxCameraCount);
    }
}