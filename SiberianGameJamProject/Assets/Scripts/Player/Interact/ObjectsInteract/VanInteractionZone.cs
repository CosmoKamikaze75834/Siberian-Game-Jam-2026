public class VanInteractionZone : Zone, IInteractable
{
    public override void Interact()
    {
        Loader.Load("VanInteriorScene");
    }
}