using UnityEngine;
using UnityEngine.UI;


public class Result : MonoBehaviour
{
    [SerializeField] Text _resultText;

    Player player;
    void Start()
    {
        _resultText.text = player._socre.ToString();
    }

}
