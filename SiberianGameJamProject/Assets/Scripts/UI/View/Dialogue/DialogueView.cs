using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private PanelDialogue _panelDialogue;
    [SerializeField] private TextMeshProUGUI _text;

    public void Show(string message)
    {
        _text.text = message;
        _panelDialogue.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _panelDialogue.gameObject.SetActive(false);
    }
}