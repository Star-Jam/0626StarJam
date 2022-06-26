using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{

    void Update()
    {
        transform.position = Input.mousePosition;
        Cursor.visible = false;
    }
}
