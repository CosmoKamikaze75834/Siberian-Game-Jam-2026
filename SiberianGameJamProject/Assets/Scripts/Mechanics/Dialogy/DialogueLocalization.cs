using System;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

[DefaultExecutionOrder(10000)]
public class DialogueLocalization : MonoBehaviour
{
    [Serializable]
    private class DialogueEntry
    {
        [TextArea(2, 4)]
        public string OriginalText;

        public string LocalizationKey;

        [NonSerialized] public string Translation;
        [NonSerialized] public string PreviousTranslation;
    }

    [SerializeField] private TextMeshProUGUI[] _dialogueTexts;
    [SerializeField] private DialogueEntry[] _entries;

    private int _version;

    private void OnEnable()
    {
        LocalizationSettings.SelectedLocaleChanged += OnLocaleChanged;
        LoadTranslations();
    }

    private void OnDisable()
    {
        LocalizationSettings.SelectedLocaleChanged -= OnLocaleChanged;
        _version++;
    }

    private void OnLocaleChanged(Locale locale)
    {
        LoadTranslations();
    }

    private void LoadTranslations()
    {
        int version = ++_version;

        foreach (DialogueEntry entry in _entries)
        {
            entry.PreviousTranslation = entry.Translation;
            entry.Translation = null;

            if (string.IsNullOrEmpty(entry.LocalizationKey))
                continue;

            DialogueEntry currentEntry = entry;

            var operation = LocalizationSettings.StringDatabase
                .GetLocalizedStringAsync(
                    "PCScene",
                    currentEntry.LocalizationKey
                );

            operation.Completed += result =>
            {
                if (!this || !isActiveAndEnabled || version != _version)
                    return;

                if (result.Status != AsyncOperationStatus.Succeeded)
                {
                    Debug.LogError(
                        $"Ошибка локализации: {currentEntry.LocalizationKey}"
                    );
                    return;
                }

                currentEntry.Translation = result.Result;

                Debug.Log(
                    $"Перевод загружен: {currentEntry.LocalizationKey} = {result.Result}"
                );

                ApplyTranslations();
            };
        }
    }

    private void LateUpdate()
    {
        ApplyTranslations();
    }

    private void ApplyTranslations()
    {
        foreach (TextMeshProUGUI text in _dialogueTexts)
        {
            if (text == null)
                continue;

            string currentText = Normalize(text.text);

            foreach (DialogueEntry entry in _entries)
            {
                if (string.IsNullOrEmpty(entry.Translation))
                    continue;

                bool isOriginal =
                    currentText == Normalize(entry.OriginalText);

                bool isPrevious =
                    !string.IsNullOrEmpty(entry.PreviousTranslation) &&
                    currentText == Normalize(entry.PreviousTranslation);

                if (!isOriginal && !isPrevious)
                    continue;

                if (text.text != entry.Translation)
                    text.text = entry.Translation;

                break;
            }
        }
    }

    private static string Normalize(string text)
    {
        return (text ?? "")
            .Replace("\r\n", "\n")
            .Replace('\u00A0', ' ')
            .Trim();
    }
}