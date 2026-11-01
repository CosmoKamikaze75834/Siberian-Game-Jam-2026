using UnityEngine;
using Zenject;

public class PlayerAnimation : MonoBehaviour
{
    private static readonly int Speed = Animator.StringToHash("Speed");

    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private IPlayerControls _controls;

    [Inject]
    private void Construct(IPlayerControls controls)
    {
        _controls = controls;
    }

    private void Update()
    {
        Vector2 direction = _controls.MoveDirection;

        _animator.SetFloat(Speed, direction.magnitude);

        if (direction.x > 0f)
        {
            _spriteRenderer.flipX = true;
        }
        else if (direction.x < 0f)
        {
            _spriteRenderer.flipX = false;
        }
    }
}