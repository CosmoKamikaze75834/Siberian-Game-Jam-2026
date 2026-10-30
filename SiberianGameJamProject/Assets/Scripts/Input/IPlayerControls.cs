using System;
using UnityEngine;

public interface IPlayerControls
{
    Vector2 MoveDirection { get; }
    event Action InteractPressed;
    Vector2 PointerPosition { get; }
}