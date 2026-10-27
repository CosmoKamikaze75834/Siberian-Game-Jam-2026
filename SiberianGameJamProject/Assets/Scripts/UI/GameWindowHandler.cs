using UnityEngine;

public class GameWindowHandler : MonoBehaviour
{
    [SerializeField] private WindowMainMenu _menu;
    [SerializeField] private WindowSettings _settings;

    private void OnEnable()
    {
        _menu.SettingsRequested += ShowSettings;
        _settings.MainMenuRequested += HideSettings;
    }

    private void OnDisable()
    {
        _menu.SettingsRequested -= ShowSettings;
        _settings.MainMenuRequested -= HideSettings;
    }

    private void ShowSettings()
    {
        _settings.Open();
        _menu.Close();
    }

    private void HideSettings()
    {
        _settings.Close();
        _menu.Open();
    }
}