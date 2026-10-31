using UnityEngine;
using Zenject;

public class WindowLoading : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    private void Start()
    {
        StartCoroutine(_sceneLoader.LoadAsync("VanInteriorScene"));
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}