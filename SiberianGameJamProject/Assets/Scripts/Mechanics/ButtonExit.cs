using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ButtonExit : MonoBehaviour
{
    // Start is called before the first frame update
    
    public void ButtonExitCliks(string name)
    {
        SceneManager.LoadScene(name);
    }
}
