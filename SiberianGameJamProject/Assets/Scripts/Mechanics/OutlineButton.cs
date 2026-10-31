using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;

public class OutlineButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] public GameObject _otlineButton;
    // Start is called before the first frame update
    public void Start()
    {
        _otlineButton.SetActive(false);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _otlineButton.SetActive(true);
       
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _otlineButton.SetActive(false); 
    }
}
