using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    [SerializeField] Text _resultText;

    Player player;
    void Start()
    {
        _resultText.text = player._socre.ToString();
    }

    public void OnBack()
    {
        SceneManager.LoadScene("TittleScene");
    }
}
