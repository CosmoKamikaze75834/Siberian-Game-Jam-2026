using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WindowMainMenu : Window
{
    [SerializeField] private Button _buttonNewGame;
    [SerializeField] private Button _buttonSettings;
    [SerializeField] private Button _buttonExit;

    private SceneLoader _sceneLoader;

    public event Action SettingsRequested;

    private void OnEnable()
    {
        _buttonNewGame.onClick.AddListener(OnPlayClicked);
        _buttonSettings.onClick.AddListener(OnSettingsClicked);
        _buttonExit.onClick.AddListener(OnExitClicked);
    }

    private void OnDisable()
    {
        _buttonNewGame.onClick.RemoveListener(OnPlayClicked);
        _buttonSettings.onClick.RemoveListener(OnSettingsClicked);
        _buttonExit.onClick.RemoveListener(OnExitClicked);
    }

    private void OnPlayClicked()
    {
        _sceneLoader.Load("LoadingScene");
    }

    private void OnSettingsClicked()
    {
        Close();
        SettingsRequested?.Invoke();
    }

    private void OnExitClicked()
    {
        Debug.Log("Exit");
        Application.Quit();
    }

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }
}