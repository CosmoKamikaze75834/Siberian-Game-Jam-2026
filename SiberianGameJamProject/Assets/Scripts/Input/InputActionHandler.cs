using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

public abstract class InputActionHandler : MonoBehaviour
{
    protected PlayerInput Input;

    protected abstract InputAction Action { get; }

    private void OnEnable()
    {
        Action.Enable();

        Action.performed += OnAction;
        Action.canceled += OnAction;
    }

    private void OnDisable()
    {
        Action.Disable();

        Action.performed -= OnAction;
        Action.canceled -= OnAction;
    }

    protected abstract void OnAction(InputAction.CallbackContext context);

    [Inject]
    private void Construct(PlayerInput playerInput)
    {
        Input = playerInput;
    }
}