using UnityEngine;

[RequireComponent(typeof(DoorSound))]
public class VanInteractionZone : Zone, IInteractable
{
    public override void Interact()
    {
        GetComponent<DoorSound>().Play();
        Loader.Load("VanInteriorScene");
    }
}