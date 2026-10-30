using UnityEngine;

public class CameraCountPresenter : MonoBehaviour
{
    [SerializeField] private CameraCountView _cameraCountView;
    [SerializeField] private CameraPlacement _placement;

    private void OnEnable()
    {
        _placement.AmountChanged += OnCameraCountChanged;
    }

    private void OnDisable()
    {
        _placement.AmountChanged -= OnCameraCountChanged;
    }

    public void OnCameraCountChanged(int count)
    {
        _cameraCountView.Display(_placement.RemainingCameraCount, _placement.MaxCameraCount);
    }
}