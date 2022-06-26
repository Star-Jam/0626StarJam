using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    Rigidbody2D _rb;
    string _playerTag = "Player";
    int _damege = 1;
    float _speed;
    Vector2 _dir;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _rb.velocity = _dir.normalized * _speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == _playerTag)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeDamege(int damege)
    {
        _damege = damege;
    }

    public void ChangeDir(Vector2 dir)
    {
        _dir = dir;
    }
}
