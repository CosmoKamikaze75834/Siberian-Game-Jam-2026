using System;
using UnityEngine;
using Zenject;

public class InputSystemPlayer : MonoBehaviour, IPlayerControls
{
    private InputMove _inputMove;
    private InputInteract _inputInteract;
    private InputPointer _inputPointer;

    public Vector2 MoveDirection => _inputMove.MoveDirection;

    public Vector2 PointerPosition => _inputPointer.PointerPosition;

    public event Action InteractPressed
    {
        add => _inputInteract.InteractPressed += value;
        remove => _inputInteract.InteractPressed -= value;
    }

    [Inject]
    private void Construct(InputMove inputMove, InputInteract inputInteract, InputPointer inputPointer)
    {
        _inputMove = inputMove;
        _inputInteract = inputInteract;
        _inputPointer = inputPointer;
    }
}