using UnityEngine;
using Zenject;

//рассчитывает позицию точки установки относительно игрока и курсора.
public class CameraPlacementPoint : MonoBehaviour
{
    [SerializeField, Min(1)] private float _cameraDistance;

    private IPlayerControls _controls;
    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        Debug.Log($"Camera: {_mainCamera}, Controls: {_controls}, Parent: {transform.parent}");
    }

    private void Update()
    {
        Vector2 mousePosition = _mainCamera.ScreenToWorldPoint(_controls.PointerPosition);

        Vector2 playerPosition = transform.parent.position;

        Vector2 direction = (mousePosition - playerPosition).normalized;

        if (direction == Vector2.zero)
            return;

        Vector2 targetPosition = playerPosition + direction * _cameraDistance;

        transform.position = new Vector3(targetPosition.x, targetPosition.y,transform.position.z);
    }

    [Inject]
    private void Construct(IPlayerControls playerControls)
    {
        _controls = playerControls;
    }
}