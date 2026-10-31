using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//устанавилвает камеру в мире
public class CameraPlacement : MonoBehaviour
{
    [SerializeField] private TrailCamera _camera;
    [SerializeField, Min(1)] private int _maxCameraCount;

    private readonly Dictionary<Vector3, TrailCamera> _spawnedCameras = new();

    public int MaxCameraCount => _maxCameraCount;
    public int RemainingCameraCount => _maxCameraCount - _progress.PlacedCameraCount;

    private GameProgress _progress;

    public event Action<int> AmountChanged;//количество камер изменилось

    private void Start()
    {
        _progress.Initialize(_maxCameraCount);

        foreach (Vector3 position in _progress.CameraPositions)
        {
            TrailCamera camera = Instantiate(_camera, position, Quaternion.identity);
            _spawnedCameras.Add(position, camera);
        }
    }

    public void Place(Vector3 position)
    {
        //компонент включён и его GameObject активен в иерархии?
        if (isActiveAndEnabled == false)
            return;

        if (_progress.PlacedCameraCount >= _maxCameraCount)
            return;

        if (_progress.HasCameraAt(position))
            return;

        TrailCamera camera = Instantiate(_camera, position, Quaternion.identity);
        _spawnedCameras.Add(position, camera);

        _progress.RegisterCameraPlaced(position);

        AmountChanged?.Invoke(RemainingCameraCount);
    }

    public bool TryCollect(Vector3 position)
    {
        if (!_spawnedCameras.TryGetValue(position, out TrailCamera camera))//ищем по указанной позиции
            return false;

        if (!_progress.TryCollectCameraAt(position))//поспал ли игрок и зарегестрирвоана ли камера?
            return false;

        Destroy(camera.gameObject);

        _spawnedCameras.Remove(position);

        AmountChanged?.Invoke(RemainingCameraCount);

        return true;
    }

    [Inject]
    private void Construct(GameProgress progress)
    {
        _progress = progress;
    }
}