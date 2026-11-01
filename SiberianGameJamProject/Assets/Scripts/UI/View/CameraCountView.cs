using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class CameraCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private LocalizedString _localizedCount;

    private int _remainingCount;
    private int _maxCount;

    private void OnEnable()
    {
        _localizedCount.Arguments = new object[]
        {
            _remainingCount,
            _maxCount
        };

        _localizedCount.StringChanged += UpdateText;
    }

    private void OnDisable()
    {
        _localizedCount.StringChanged -= UpdateText;
    }

    public void Display(int remainingCount, int maxCount)
    {
        _remainingCount = remainingCount;
        _maxCount = maxCount;

        _localizedCount.Arguments = new object[]
        {
        remainingCount,
        maxCount
        };

        _localizedCount.RefreshString();
    }

    private void UpdateText(string value)
    {
        _text.text = value;
    }
}