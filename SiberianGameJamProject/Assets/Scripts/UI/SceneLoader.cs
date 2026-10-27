using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void Load(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator LoadAsync(string sceneName)
    {
        AsyncOperation waitLoading = SceneManager.LoadSceneAsync(sceneName);
        yield return new WaitUntil (() => waitLoading.isDone);
    }
}