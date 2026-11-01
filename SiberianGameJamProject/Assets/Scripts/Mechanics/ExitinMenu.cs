using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitinMenu : MonoBehaviour
{
  public void MenuExit(string name)
    {
        SceneManager.LoadScene(name);
    }
}
