using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : Window
{
    [SerializeField] private Button _buttonNewGame;
    [SerializeField] private Button _buttonContinue;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonExit;

    private SceneLoader _sceneLoader;

    public event Action SettingsRequested;

    private void OnEnable()
    {
        _buttonNewGame.onClick.AddListener(OnPlayClicked);
        _buttonExit.onClick.AddListener(OnExitClicked);
        _buttonSettings.onClick.AddListener(OnSettingsClicked);
    }

    private void OnDisable()
    {
        _buttonNewGame.onClick.RemoveListener(OnPlayClicked);
        _buttonExit.onClick.RemoveListener(OnExitClicked);
        _buttonSettings.onClick.RemoveListener(OnSettingsClicked);
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

    private void OnSettingsClicked()
    {
        SettingsRequested?.Invoke();
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}