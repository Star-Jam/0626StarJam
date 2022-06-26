using UnityEngine;
using UnityEngine.UI;


public class Result : MonoBehaviour
{
    

    int _resultScore;
    Player player;
    GameManager gameManager;
    void Start()
    {
        _resultScore = player._socre;
        player._countText.text = player._socre.ToString();
    }

}
