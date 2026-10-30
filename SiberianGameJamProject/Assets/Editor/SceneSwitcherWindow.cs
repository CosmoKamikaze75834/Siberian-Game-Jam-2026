using System.IO;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public class SceneSwitcherWindow : EditorWindow
{
    private Vector2 _scrollPosition;

    [MenuItem("Window/Scene Switcher")]
    public static void OpenWindow()
    {
        GetWindow<SceneSwitcherWindow>("Scenes");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Game Scenes", EditorStyles.boldLabel);

        _scrollPosition = EditorGUILayout.BeginScrollView(_scrollPosition);

        foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (!scene.enabled)
                continue;

            string path = scene.path;
            string sceneName = Path.GetFileNameWithoutExtension(path);

            if (GUILayout.Button(sceneName))
            {
                if (EditorApplication.isPlayingOrWillChangePlaymode)
                {
                    Debug.LogWarning("Останови Play Mode перед сменой сцены.");
                    continue;
                }

                if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
                    EditorSceneManager.OpenScene(path);
            }
        }

        EditorGUILayout.EndScrollView();
    }
}