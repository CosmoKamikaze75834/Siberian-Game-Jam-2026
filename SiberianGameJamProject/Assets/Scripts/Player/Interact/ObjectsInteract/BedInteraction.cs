using System;
using UnityEngine;

public class BedInteraction : MonoBehaviour, IInteractable
{
    public event Action InteractionRequested;

    public void Interact()
    {
        InteractionRequested?.Invoke();
    }
}
