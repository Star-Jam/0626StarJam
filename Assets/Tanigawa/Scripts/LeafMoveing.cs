using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafMoveing : MonoBehaviour
{
    public float _speed = 0.05f;

    // Update is called once per frame
    void Update()
    {//�����ňړ�������
        Vector2 v = new Vector2(-_speed, 0);
        transform.Translate(v);
    }
}
