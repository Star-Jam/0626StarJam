using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public int Damege => _damege;
    public float Speed => _speed;
    public Vector2 Dir => _dir;
    public Sprite Sprite => _sprite;

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

    int _damege;
    float _speed;
    Vector2 _dir;
    Sprite _sprite;

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
            _sprite = _obstacle[_obstacleNumber].Sprite;//スプライトを変更
            _damege = _obstacle[_obstacleNumber].Damege;//ダメージを変更
            _speed = Random.Range(_obstacle[_obstacleNumber].MinSpeed, _obstacle[_obstacleNumber].MaxSpeed);//スピードを変更
            _dir.x = Random.Range(_obstacle[_obstacleNumber].MinDir.x, _obstacle[_obstacleNumber].MaxDir.x);
            _dir.y = Random.Range(_obstacle[_obstacleNumber].MinDir.y, _obstacle[_obstacleNumber].MaxDir.y);
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
        public float MinSpeed => _minSpeed;
        public float MaxSpeed => _maxSpeed;
        public Vector2 MinDir => _minDir;
        public Vector2 MaxDir => _maxDir;
        public Sprite Sprite => _sprite;

        [SerializeField]
        [Header("障害物の名前")]
        string _obstacleName;

        [SerializeField]
        [Header("プレイヤーの残機を減らす量")]
        int _damege;

        [SerializeField]
        [Header("最短スピード")]
        float _minSpeed;

        [SerializeField]
        [Header("最長スピード")]
        float _maxSpeed;

        [SerializeField]
        [Header("最小の移動方向")]
        Vector2 _minDir;

        [SerializeField]
        [Header("最大の移動方向")]
        Vector2 _maxDir;

        [SerializeField]
        [Header("障害物のスプライト")]
        Sprite _sprite;
    }
}
