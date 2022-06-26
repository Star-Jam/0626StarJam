using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    public void Active(bool active)
    {
        switch (active)
        {
            case true:
                gameObject.SetActive(true);
                break;
            case false:
                gameObject.SetActive(false);
                break;
        }
    }
}
