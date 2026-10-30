using UnityEngine;

public class VanInteractionZone : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Игрок зашёл в фургон");
    }
}