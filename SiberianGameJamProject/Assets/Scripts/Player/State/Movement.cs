using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Range(0, 10)]
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private IPlayerControls _motionControl;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var direction = _motionControl.MoveDirection;
        direction *= _speed;

        _rigidbody2D.velocity = direction;
    }

    [Inject]
    private void Construct(IPlayerControls motionControl)
    {
        _motionControl = motionControl;
    }
}