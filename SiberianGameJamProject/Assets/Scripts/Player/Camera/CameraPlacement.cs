using System;
using UnityEngine;

//устанавилвает камеру в мире
public class CameraPlacement : MonoBehaviour
{
    [SerializeField] private TrailCamera _camera;
    [SerializeField] private Transform _pointCamera;
    [SerializeField, Min(1)] private int _maxCameraCount;

    private int _placedCameraCount;//уже установленные камеры

    public int MaxCameraCount => _maxCameraCount;
    public int RemainingCameraCount => _maxCameraCount - _placedCameraCount;

    public event Action<int> AmountChanged;//количество камер изменилось

    private void OnEnable() =>
        Debug.Log("Заглушка");

    public void Place()
    {
        //компонент включён и его GameObject активен в иерархии?
        if (isActiveAndEnabled == false)
            return;

        if(_placedCameraCount >= _maxCameraCount)
            return;

        Instantiate(_camera, _pointCamera.position, _pointCamera.rotation);
        _placedCameraCount++;

        AmountChanged?.Invoke(RemainingCameraCount);
    }
}