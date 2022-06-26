using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public float _speed = 0.05f;
    public float _pow = 0.05f;
    public float _T = 1.0f;

    // Update is called once per frame
    void Update()
    {//sinÉJÅ[ÉuÇ≈à⁄ìÆÇ≥ÇπÇÈ
        float f = 1.0f / _T;
        float sin = Mathf.Sin(2 * Mathf.PI * f * Time.time);

        Vector2 v = new Vector2(-_speed, sin * _pow);
        transform.Translate(v);
    }
}
