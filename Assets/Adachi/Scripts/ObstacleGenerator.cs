using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    [Header("障害物")]
    List<Obstacle> _obstacle = new List<Obstacle>();

    [SerializeField]
    [Header("左の範囲")]
    float _leftLimit;

    [SerializeField]
    [Header("右の範囲")]
    float _rightLimit;

    [SerializeField]
    [Header("下の範囲")]
    float _downLimit;

    [SerializeField]
    [Header("上の範囲")]
    float _upperLimit;

    [SerializeField]
    [Header("最短の秒数(ミリ秒)")]
    int _minSeconds;

    [SerializeField]
    [Header("最長の秒数(ミリ秒)")]
    int _maxSeconds;

    [SerializeField]
    [Header("障害物のオブジェクト")]
    GameObject _obstacleObject;

    ObstacleController _obstacleController;

    /// <summary>生成位置</summary>
    Vector2 _generationPos;
    /// <summary>障害物の番号</summary>
    int _obstacleNumber;

    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = _obstacleObject.GetComponent<SpriteRenderer>();
        _obstacleController = _obstacleObject.GetComponent<ObstacleController>();
    }

    /// <summary>ジェネレーター</summary>
    async void Generator()
    {
        while (true)
        {
            await Task.Delay (Random.Range(_minSeconds, _maxSeconds));//待ち時間
            _obstacleNumber = Random.Range(0, _obstacle.Count);
            _spriteRenderer.sprite = _obstacle[_obstacleNumber].Sprite;//スプライトを変更
            _obstacleController.ChangeDamege(_obstacle[_obstacleNumber].Damege);//ダメージを変更
            _generationPos.x = Random.Range(_leftLimit, _rightLimit);//生成位置を変更(X)
            _generationPos.y = Random.Range(_downLimit, _upperLimit);//生成位置を変更(Y)
            //引数に入るのは(生成したいオブジェクト,生成位置,回転値)
            Instantiate(_obstacleObject, _generationPos, Quaternion.identity);
            Debug.Log(1111);
        }
    }

    [System.Serializable]
    public class Obstacle
    {
        public int Damege => _damege;
        public Sprite Sprite => _sprite;

        [SerializeField]
        [Header("障害物の名前")]
        string _obstacleName;

        [SerializeField]
        [Header("プレイヤーの残機を減らす量")]
        int _damege;

        [SerializeField]
        [Header("スピード")]
        float _speed;

        [SerializeField]
        [Header("障害物のスプライト")]
        Sprite _sprite;
    }
}
