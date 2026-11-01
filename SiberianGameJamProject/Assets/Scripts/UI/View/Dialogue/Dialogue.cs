using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.ResourceManagement.AsyncOperations;

public class Dialogue : MonoBehaviour
{
    [SerializeField] private DialogueView _dialogueView;

    public void Show(DialogueId id)
    {

        Debug.Log($"Вызван диалог: {id}");
        _dialogueView.Show("TEST");

        var operation = LocalizationSettings.StringDatabase
            .GetLocalizedStringAsync("Gameplay", id.ToString());

        operation.Completed += result =>
        {
            if (!this || !isActiveAndEnabled)
                return;

            if (result.Status != AsyncOperationStatus.Succeeded)
            {
                Debug.LogWarning($"Не удалось загрузить диалог: {id}");
                return;
            }

            _dialogueView.Show(result.Result);
        };
    }
}