using UnityEngine;

public class SleepView : MonoBehaviour
{
    [SerializeField] private GameObject _sleepImage;

    public void Show()
    {
        _sleepImage.SetActive(true);
    }

    public void Hide()
    {
        _sleepImage.SetActive(false);
    }
}