using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class WindowSettingsGraphic : MonoBehaviour
{
    public TMP_Dropdown _graphicDropDown;
    public Toggle _fullScreenTogle;
   

    Resolution[] AllResolutions;
    bool IsFullScreen;
    int SelectedResolution;
    List<Resolution> SelectedResolutionList = new List<Resolution>();
    // Start is called before the first frame update
    void Start()
    {
        IsFullScreen = true;
        AllResolutions = Screen.resolutions;
        List<string> resolutionStringList = new List<string>();
        string newRes;
        foreach (Resolution res in AllResolutions)
        {
            newRes = res.width.ToString() + "x" + res.height.ToString();
            if (!resolutionStringList.Contains(newREs))
            {
                resolutionStringList.Add(newRes);
                resolutionStringList.Add(res.ToString);
                    }
        }
        _graphicDropDown.AddOptions(resolutionStringList);
    }

    public void ChangeResolution()
    {
        SelectedResolution = _graphicDropDown.value;
        Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, IsFullScreen);
    }

    public void ChanheFullScreen()
    {
        IsFullScreen = _fullScreenTogle.isOn;
        Screen.SetResolution(SelectedResolutionList[SelectedResolution].width, SelectedResolutionList[SelectedResolution].height, IsFullScreen);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
