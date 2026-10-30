using UnityEngine;

//устанавилвает камеру в мире
public class CameraPlacement : MonoBehaviour
{
    [SerializeField] private TrailCamera _camera;
    [SerializeField] private Transform _pointCamera;
    [SerializeField] private int _maxCameraCount = 10;

    private int _placedCameraCount;//уже установленные камеры

    public void Place()
    {
        if(_placedCameraCount >= _maxCameraCount)
            return;

        Instantiate(_camera, _pointCamera.position, _pointCamera.rotation);
        _placedCameraCount++;
    }
}