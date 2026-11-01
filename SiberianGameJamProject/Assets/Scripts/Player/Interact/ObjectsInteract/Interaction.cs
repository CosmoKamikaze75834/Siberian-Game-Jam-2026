using System;
using UnityEngine;

public class Interaction : MonoBehaviour, IInteractable
{
    [SerializeField] private InteractionType _interactionType;

    public event Action<InteractionType> InteractionRequested;

    public void Interact()
    {
        Debug.Log($"Взаимодействие с {gameObject.name}, тип: {_interactionType}");
        InteractionRequested?.Invoke(_interactionType);
    }
}