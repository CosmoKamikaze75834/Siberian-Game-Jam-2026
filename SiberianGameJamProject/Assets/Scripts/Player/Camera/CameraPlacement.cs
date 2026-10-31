using System;
using UnityEngine;
using Zenject;

//устанавилвает камеру в мире
public class CameraPlacement : MonoBehaviour
{
    [SerializeField] private TrailCamera _camera;
    [SerializeField] private Transform _pointCamera;
    [SerializeField, Min(1)] private int _maxCameraCount;

    public int MaxCameraCount => _maxCameraCount;
    public int RemainingCameraCount => _maxCameraCount - _progress.PlacedCameraCount;

    private GameProgress _progress;

    public event Action<int> AmountChanged;//количество камер изменилось

    private void Start()
    {
        _progress.Initialize(_maxCameraCount);

        foreach (Vector3 position in _progress.CameraPositions)
            Instantiate(_camera, position, Quaternion.identity);
    }

    public void Place()
    {
        //компонент включён и его GameObject активен в иерархии?
        if (isActiveAndEnabled == false)
            return;

        if(_progress.PlacedCameraCount >= _maxCameraCount)
            return;

        Vector3 position = _pointCamera.position;

        Instantiate(_camera, position, _pointCamera.rotation);

        _progress.RegisterCameraPlaced(position);

        AmountChanged?.Invoke(RemainingCameraCount);
    }

    [Inject]
    private void Construct(GameProgress progress)
    {
        _progress = progress;
    }
}