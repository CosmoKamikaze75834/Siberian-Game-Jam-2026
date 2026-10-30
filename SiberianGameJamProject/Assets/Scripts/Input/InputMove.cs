using UnityEngine;
using UnityEngine.InputSystem;

public class InputMove : InputActionHandler
{
    public Vector2 MoveDirection { get; private set; }

    protected override InputAction Action => Input.Player.Move;

    protected override void OnAction(InputAction.CallbackContext context) =>
        MoveDirection = context.ReadValue<Vector2>();
}