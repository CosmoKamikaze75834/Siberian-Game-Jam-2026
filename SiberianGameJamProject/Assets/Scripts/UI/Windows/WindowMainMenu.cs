using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : MonoBehaviour
{
    [SerializeField] private Button _buttonNewGame;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonExit;

    private SceneLoader _sceneLoader;

    private void OnEnable()
    {
        _buttonNewGame.onClick.AddListener(OnPlayClicked);
        _buttonExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _buttonNewGame.onClick.RemoveListener(OnPlayClicked);
        _buttonExit.onClick.RemoveListener(OnExitClicked);
    }

    private void OnPlayClicked()
    {
        _sceneLoader.Load("LoadingScene");
    }

    private void OnExitClicked()
    {
        Application.Quit();
        Debug.Log("Вы вышли из игры");
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}