using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

//устанавилвает камеру в мире
public class CameraPlacement : MonoBehaviour
{
    [SerializeField] private TrailCamera _camera;
    [SerializeField, Min(1)] private int _maxCameraCount = 3;

    private GameProgress _progress;

    private readonly Dictionary<Vector3, TrailCamera> _spawnedCameras = new();

    public int MaxCameraCount => _maxCameraCount;
    public int RemainingCameraCount => _maxCameraCount - _progress.PlacedCameraCount;

    public event Action<int> AmountChanged;

    [Inject]
    private void Construct(GameProgress progress)
    {
        _progress = progress;
    }

    private void Start()
    {
        _progress.Initialize(_maxCameraCount);

        foreach (Vector3 position in _progress.CameraPositions)
        {
            SpawnCamera(position);
        }

        AmountChanged?.Invoke(RemainingCameraCount);
    }

    public void Place(Vector3 position)
    {
        if (!isActiveAndEnabled)
            return;

        if (_progress.HasCameraAt(position))
        {
            Debug.Log("Камера уже установлена в этой точке");
            return;
        }

        if (_progress.PlacedCameraCount >= _maxCameraCount)
        {
            Debug.Log("Все камеры уже установлены");
            return;
        }

        if (!SpawnCamera(position))
            return;

        _progress.RegisterCameraPlaced(position);

        AmountChanged?.Invoke(RemainingCameraCount);

        Debug.Log($"Камера успешно установлена: {position}");
    }

    public bool TryCollect(Vector3 position)
    {
        if (!_spawnedCameras.TryGetValue(position, out TrailCamera camera))
            return false;

        if (!_progress.TryCollectCameraAt(position))
            return false;

        Destroy(camera.gameObject);

        _spawnedCameras.Remove(position);

        AmountChanged?.Invoke(RemainingCameraCount);

        return true;
    }

    private bool SpawnCamera(Vector3 position)
    {
        if (_camera == null)
        {
            Debug.LogError("Префаб TrailCamera не назначен!");
            return false;
        }

        TrailCamera camera = Instantiate(
            _camera,
            position,
            Quaternion.identity
        );

        SpriteRenderer[] renderers =
            camera.GetComponentsInChildren<SpriteRenderer>(true);

        if (renderers.Length == 0)
        {
            Debug.LogError("У TrailCamera нет SpriteRenderer!");
        }

        foreach (SpriteRenderer spriteRenderer in renderers)
        {
            spriteRenderer.gameObject.SetActive(true);
            spriteRenderer.enabled = true;
            spriteRenderer.color = Color.white;

            if (spriteRenderer.sprite == null)
            {
                Debug.LogError("У камеры не назначен Sprite!");
            }
        }

        _spawnedCameras.Add(position, camera);

        return true;
    }
}