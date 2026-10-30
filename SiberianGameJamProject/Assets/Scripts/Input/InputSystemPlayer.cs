using UnityEngine;
using Zenject;

public class InputSystemPlayer : MonoBehaviour, IMotionControl
{
    private InputMove _inputMove;

    public Vector2 MoveDirection => _inputMove.MoveDirection;

    [Inject]
    private void Construct(InputMove inputMove)
    {
        _inputMove = inputMove;
    }
}