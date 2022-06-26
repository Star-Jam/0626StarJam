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
            UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
            #else
            Application.Quit();//�Q�[���v���C�I��
            #endif
        }
        else
        {
            SceneManager.LoadScene(sceneName);
        }

    }
}
