using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Player player;
    [SerializeField] Text _resultText;

    void Start()
    {
        
        player = FindObjectOfType<Player>();
        DontDestroyOnLoad(gameObject);
    }

    
    
}
