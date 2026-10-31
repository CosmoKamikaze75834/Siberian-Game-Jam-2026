using System;
using UnityEngine;
using Zenject;

public class InputSystemPlayer : MonoBehaviour, IPlayerControls
{
    private InputMove _inputMove;
    private InputInteract _inputInteract;

    public Vector2 MoveDirection => _inputMove.MoveDirection;

    public event Action InteractPressed
    {
        add => _inputInteract.InteractPressed += value;
        remove => _inputInteract.InteractPressed -= value;
    }

    [Inject]
    private void Construct(InputMove inputMove, InputInteract inputInteract)
    {
        _inputMove = inputMove;
        _inputInteract = inputInteract;
    }
}