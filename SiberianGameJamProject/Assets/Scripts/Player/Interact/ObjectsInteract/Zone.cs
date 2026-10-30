using UnityEngine;
using Zenject;

public abstract class Zone : MonoBehaviour
{
    protected SceneLoader Loader;

    public abstract void Interact();

    [Inject]
    protected void Construct(SceneLoader sceneloader)
    {
        Loader = sceneloader;
    }
}