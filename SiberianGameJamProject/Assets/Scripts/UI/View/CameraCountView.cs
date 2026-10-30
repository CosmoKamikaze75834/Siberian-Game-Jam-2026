using TMPro;
using UnityEngine;

public class CameraCountView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Display(int remainingCount, int maxCount)
    {
        _text.text = $"Камеры: {remainingCount}/{maxCount}";
    }
}