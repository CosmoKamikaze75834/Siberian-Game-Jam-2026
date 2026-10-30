using UnityEngine;
using Zenject;

public class VanInteractionZone : MonoBehaviour, IInteractable
{
    private SceneLoader _loader;

    public void Interact()
    {
        _loader.Load("VanInteriorScene");
    }

    [Inject]
    private void Construct(SceneLoader sceneloader)
    {
        _loader = sceneloader;
    }
}