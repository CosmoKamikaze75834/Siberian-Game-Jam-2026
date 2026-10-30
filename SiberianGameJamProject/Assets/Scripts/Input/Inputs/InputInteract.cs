using System;
using UnityEngine.InputSystem;

public class InputInteract : InputActionHandler
{
    public event Action InteractPressed;

    protected override InputAction Action => Input.Player.Interact;

    protected override void OnAction(InputAction.CallbackContext context)
    {
        if (context.performed)
            InteractPressed?.Invoke();
    }
       
}