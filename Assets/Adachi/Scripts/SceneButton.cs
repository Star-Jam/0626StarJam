using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    public void SceneLoad(string sceneName)
    {
        if (sceneName == "Exit")
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
            #else
            Application.Quit();//ゲームプレイ終了
            #endif
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
