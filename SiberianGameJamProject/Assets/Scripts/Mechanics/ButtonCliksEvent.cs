using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonCliksEvent : MonoBehaviour
{
    [SerializeField] GameObject _folderandsprogram;
    [SerializeField] GameObject _buttonClose12;
    // Start is called before the first frame update
    public void Start()
    {
        _folderandsprogram.SetActive(false);
        _buttonClose12.SetActive(false);
    }
    
    public void OpenFolder()
    {
        _folderandsprogram.SetActive(true);
        _buttonClose12.SetActive(true);
    }
    public void CloseFolder()
    {

        _folderandsprogram.SetActive(false);
        _buttonClose12.SetActive(false);
    }
}
