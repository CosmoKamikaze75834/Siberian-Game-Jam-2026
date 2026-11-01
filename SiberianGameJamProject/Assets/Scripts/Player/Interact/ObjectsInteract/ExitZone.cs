using UnityEngine;

[RequireComponent(typeof(DoorSound))]
public class ExitZone : Zone, IInteractable
{
    public override void Interact()
    {
        GetComponent<DoorSound>().Play();
        Loader.Load("GameplayScene");
    }
}