using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogyMeneger : MonoBehaviour
{
    [Header("Ссылка на UI текст")]
    [SerializeField] TextMeshProUGUI _dialogyText;
    [SerializeField] public GameObject _dialogeWin;

    public void ShowDialogy(string text)
    {
      
        _dialogyText.text = text;
    }

    public void ClainerDialogy()
    {
        _dialogyText.text = "";
    }

}
