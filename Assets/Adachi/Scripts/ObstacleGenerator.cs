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
    [Header("��Q��")]
    List<Obstacle> _obstacle = new List<Obstacle>();

    [SerializeField]
    [Header("���͈̔�")]
    float _leftLimit;

    [SerializeField]
    [Header("�E�͈̔�")]
    float _rightLimit;

    [SerializeField]
    [Header("���͈̔�")]
    float _downLimit;

    [SerializeField]
    [Header("��͈̔�")]
    float _upperLimit;

    [SerializeField]
    [Header("�ŒZ�̕b��(�~���b)")]
    int _minSeconds;

    [SerializeField]
    [Header("�Œ��̕b��(�~���b)")]
    int _maxSeconds;

    [SerializeField]
    [Header("��Q���̃I�u�W�F�N�g")]
    GameObject _obstacleObject;

    ObstacleController _obstacleController;

    /// <summary>�����ʒu</summary>
    Vector2 _generationPos;
    /// <summary>��Q���̔ԍ�</summary>
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

    /// <summary>�W�F�l���[�^�[</summary>
    async void Generator()
    {
        while (true)
        {
            await Task.Delay (Random.Range(_minSeconds, _maxSeconds));//�҂�����
            _obstacleNumber = Random.Range(0, _obstacle.Count);
            _sprite = _obstacle[_obstacleNumber].Sprite;//�X�v���C�g��ύX
            _damege = _obstacle[_obstacleNumber].Damege;//�_���[�W��ύX
            _speed = Random.Range(_obstacle[_obstacleNumber].MinSpeed, _obstacle[_obstacleNumber].MaxSpeed);//�X�s�[�h��ύX
            _dir.x = Random.Range(_obstacle[_obstacleNumber].MinDir.x, _obstacle[_obstacleNumber].MaxDir.x);
            _dir.y = Random.Range(_obstacle[_obstacleNumber].MinDir.y, _obstacle[_obstacleNumber].MaxDir.y);
            _generationPos.x = Random.Range(_leftLimit, _rightLimit);//�����ʒu��ύX(X)
            _generationPos.y = Random.Range(_downLimit, _upperLimit);//�����ʒu��ύX(Y)
            //�����ɓ���̂�(�����������I�u�W�F�N�g,�����ʒu,��]�l)
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
        [Header("��Q���̖��O")]
        string _obstacleName;

        [SerializeField]
        [Header("�v���C���[�̎c�@�����炷��")]
        int _damege;

        [SerializeField]
        [Header("�ŒZ�X�s�[�h")]
        float _minSpeed;

        [SerializeField]
        [Header("�Œ��X�s�[�h")]
        float _maxSpeed;

        [SerializeField]
        [Header("�ŏ��̈ړ�����")]
        Vector2 _minDir;

        [SerializeField]
        [Header("�ő�̈ړ�����")]
        Vector2 _maxDir;

        [SerializeField]
        [Header("��Q���̃X�v���C�g")]
        Sprite _sprite;
    }
}
