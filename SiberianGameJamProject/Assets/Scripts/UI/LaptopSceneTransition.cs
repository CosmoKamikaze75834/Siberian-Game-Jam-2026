using UnityEngine;
using Zenject;

public class LaptopSceneTransition : MonoBehaviour
{
    [SerializeField] private Interaction _laptopInteraction;

    private GameProgress _progress;
    private SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _laptopInteraction.InteractionRequested += OnInteractionRequested;
    }

    private void OnDisable()
    {
        _laptopInteraction.InteractionRequested -= OnInteractionRequested;
    }

    private void OnInteractionRequested(InteractionType type)
    {
        if (type != InteractionType.Laptop)
            return;

        if (!_progress.AllCamerasCollected)
            return;

        _sceneLoader.Load("PKWindow");
    }

    [Inject]
    private void Construct(GameProgress progress, SceneLoader sceneLoader)
    {
        _progress = progress;
        _sceneLoader = sceneLoader;
    }
}