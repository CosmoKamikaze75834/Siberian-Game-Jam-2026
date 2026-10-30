using UnityEngine;
using UnityEngine.InputSystem;

public class InputPointer : InputActionHandler
{
    public Vector2 PointerPosition { get; private set; }

    protected override InputAction Action => Input.Player.PointerPosition;

    protected override void OnAction(InputAction.CallbackContext context) =>
        PointerPosition = context.ReadValue<Vector2>();
}