using UnityEngine;

public abstract class Window : MonoBehaviour
{
    private const float HiddenAlpha = 0f;
    private const float VisibleAlpha = 1f;

    [SerializeField] private CanvasGroup _windowGroup;

    protected void Open()
    {
        SetWindowState(VisibleAlpha, true);
    }

    protected void Close()
    {
        SetWindowState(HiddenAlpha, false);
    }

    private void SetWindowState(float value, bool isOpen)
    {
        _windowGroup.alpha = value;
        _windowGroup.interactable = isOpen;
        _windowGroup.blocksRaycasts = isOpen;
    }
}