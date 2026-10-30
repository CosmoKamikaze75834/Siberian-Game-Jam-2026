public class ExitZone : Zone, IInteractable
{
    public override void Interact()
    {
        Loader.Load("GameplayScene");
    }
}