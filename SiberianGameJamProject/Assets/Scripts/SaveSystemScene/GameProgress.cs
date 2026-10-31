using System;
using System.Collections.Generic;
using UnityEngine;

//длоя сохранения между сценой вагона и леса
public class GameProgress
{
    public int MaxCameraCount { get; private set; }//всего доступно камер
    public int PlacedCameraCount => _cameraPositions.Count;

    private readonly List<Vector3> _cameraPositions = new();

    public bool AllCamerasPlaced => MaxCameraCount > 0 && PlacedCameraCount >= MaxCameraCount;

    public IReadOnlyList<Vector3> CameraPositions => _cameraPositions;

    public event Action AllCamerasPlacedEvent;//все камеры установлены

    //сон игрока
    public bool HasSlept { get; private set; }//факт завершения сна

    public void CompleteSleep()
    {
        HasSlept = true;
    }

    public void Initialize(int maxCount)
    {
        MaxCameraCount = maxCount;
    }

    public void RegisterCameraPlaced(Vector3 position)
    {
        if (AllCamerasPlaced)
            return;

        _cameraPositions.Add(position);

        if (AllCamerasPlaced)
            AllCamerasPlacedEvent?.Invoke();
    }
}