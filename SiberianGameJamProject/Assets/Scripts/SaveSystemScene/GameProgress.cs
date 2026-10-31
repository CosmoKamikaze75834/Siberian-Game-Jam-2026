using System;
using System.Collections.Generic;
using UnityEngine;

//для сохранения между сценой вагона и леса
public class GameProgress
{
    private readonly List<Vector3> _cameraPositions = new();

    public int MaxCameraCount { get; private set; }//всего доступно камер
    public int PlacedCameraCount => _cameraPositions.Count;//количество камер которые сейчас в лесу

    public bool AllCamerasPlaced => MaxCameraCount > 0 && PlacedCameraCount >= MaxCameraCount;//все камеры расставлены?

    public IReadOnlyList<Vector3> CameraPositions => _cameraPositions;//уникальный список типа вектор 3 содержит в себе позиции камер

    public bool HasSlept { get; private set; }

    public bool AllCamerasCollected => HasSlept && PlacedCameraCount == 0;

    public event Action AllCamerasPlacedEvent;
    public event Action AllCamerasCollectedEvent;

    public void CompleteSleep()
    {
        HasSlept = true;
    }

    public void Initialize(int maxCount)
    {
        MaxCameraCount = maxCount;
    }

    //зарегестрировать камеру
    public void RegisterCameraPlaced(Vector3 position)
    {
        if (AllCamerasPlaced)
            return;

        _cameraPositions.Add(position);

        if (AllCamerasPlaced)
            AllCamerasPlacedEvent?.Invoke();
    }

    //есть ли установленная камера в указанной позиции
    public bool HasCameraAt(Vector3 position)
    {
        return _cameraPositions.Contains(position);//ищет указанную позицию в списке
    }

    //регистрируем сбор камер удаляя её позицию из списка
    public bool TryCollectCameraAt(Vector3 position)
    {
        if (!HasSlept)
            return false;

        if(!_cameraPositions.Remove(position))
            return false;

        if (AllCamerasCollected)
            AllCamerasCollectedEvent?.Invoke();

        return true;
    }
}