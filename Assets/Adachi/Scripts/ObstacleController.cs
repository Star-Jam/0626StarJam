using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    public int Damage => _damege;

    [SerializeField]
    [Header("ジェネレーター")]
    GameObject _generator;

    Rigidbody2D _rb;
    string _playerTag = "Player";
    int _damege;
    float _speed;
    Vector3 _dir;
    ObstacleGenerator _obstacleGenerator;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _obstacleGenerator = _generator.GetComponent<ObstacleGenerator>();
        _damege = _obstacleGenerator.Damege;
        _speed = _obstacleGenerator.Speed;
        _dir = _obstacleGenerator.Dir;
        _spriteRenderer.sprite = _obstacleGenerator.Sprite;
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

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
