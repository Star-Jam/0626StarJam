using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public int Damege => _damege;
    public float Speed => _speed;
    public Vector3 Dir => _dir;
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
    [Header("最短の秒数)")]
    float _minSeconds;

    [SerializeField]
    [Header("最長の秒数")]
    float _maxSeconds;

    [SerializeField]
    [Header("障害物のオブジェクト")]
    GameObject _obstacleObject;

    [SerializeField]
    [Header("プレイヤーのタグ")]
    string _playerTag = "Player";

    [SerializeField]
    [Header("プレイヤーに向けて飛んでいくオブジェクトの名前")]
    string _followName = "石";

    ObstacleController _obstacleController;

    /// <summary>生成位置</summary>
    Vector3 _generationPos;
    /// <summary>障害物の番号</summary>
    int _obstacleNumber;


    int _damege;
    float _speed;
    Vector3 _dir;
    Sprite _sprite;
    GameObject _player;


    void Awake()
    {
        _obstacleController = _obstacleObject.GetComponent<ObstacleController>();
        _player = GameObject.FindWithTag(_playerTag);
        StartCoroutine(Generator());
    }

    /// <summary>ジェネレーター</summary>
    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSeconds, _maxSeconds));//待ち時間
            _obstacleNumber = Random.Range(0, _obstacle.Count);
            _sprite = _obstacle[_obstacleNumber].Sprite;//スプライトを変更
            _damege = _obstacle[_obstacleNumber].Damege;//ダメージを変更
            _speed = Random.Range(_obstacle[_obstacleNumber].MinSpeed, _obstacle[_obstacleNumber].MaxSpeed);//スピードを変更
                                                                                                                    
            //向きを変更
            _dir.x = Random.Range(_obstacle[_obstacleNumber].MinDir.x, _obstacle[_obstacleNumber].MaxDir.x);
            _dir.y = Random.Range(_obstacle[_obstacleNumber].MinDir.y, _obstacle[_obstacleNumber].MaxDir.y);

            if (_obstacle[_obstacleNumber].ObstacleName == _followName)
            {
                _dir = _player.transform.position - _generationPos;
            }
            else
            {
                _generationPos.x = Random.Range(_leftLimit, _rightLimit);//生成位置を変更(X)
                _generationPos.y = Random.Range(_downLimit, _upperLimit);//生成位置を変更(Y)
            }
            
            
            _obstacleObject.gameObject.SetActive(true);
            //引数に入るのは(生成したいオブジェクト,生成位置,回転値)
            Instantiate(_obstacleObject, _generationPos, Quaternion.identity);
            _obstacleObject.gameObject.SetActive(false);
            Debug.Log(1111);
        }
    }

    [System.Serializable]
    public class Obstacle
    {
        public string ObstacleName => _obstacleName;
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
