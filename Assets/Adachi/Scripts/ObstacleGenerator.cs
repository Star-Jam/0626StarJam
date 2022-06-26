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
    [Header("�ŒZ�̕b��)")]
    float _minSeconds;

    [SerializeField]
    [Header("�Œ��̕b��")]
    float _maxSeconds;

    [SerializeField]
    [Header("��Q���̃I�u�W�F�N�g")]
    GameObject _obstacleObject;

    [SerializeField]
    [Header("�v���C���[�̃^�O")]
    string _playerTag = "Player";

    [SerializeField]
    [Header("�v���C���[�Ɍ����Ĕ��ł����I�u�W�F�N�g�̖��O")]
    string _followName = "��";

    ObstacleController _obstacleController;

    /// <summary>�����ʒu</summary>
    Vector3 _generationPos;
    /// <summary>��Q���̔ԍ�</summary>
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

    /// <summary>�W�F�l���[�^�[</summary>
    IEnumerator Generator()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(_minSeconds, _maxSeconds));//�҂�����
            _obstacleNumber = Random.Range(0, _obstacle.Count);
            _sprite = _obstacle[_obstacleNumber].Sprite;//�X�v���C�g��ύX
            _damege = _obstacle[_obstacleNumber].Damege;//�_���[�W��ύX
            _speed = Random.Range(_obstacle[_obstacleNumber].MinSpeed, _obstacle[_obstacleNumber].MaxSpeed);//�X�s�[�h��ύX
                                                                                                                    
            //������ύX
            _dir.x = Random.Range(_obstacle[_obstacleNumber].MinDir.x, _obstacle[_obstacleNumber].MaxDir.x);
            _dir.y = Random.Range(_obstacle[_obstacleNumber].MinDir.y, _obstacle[_obstacleNumber].MaxDir.y);

            if (_obstacle[_obstacleNumber].ObstacleName == _followName)
            {
                _dir = _player.transform.position - _generationPos;
            }
            else
            {
                _generationPos.x = Random.Range(_leftLimit, _rightLimit);//�����ʒu��ύX(X)
                _generationPos.y = Random.Range(_downLimit, _upperLimit);//�����ʒu��ύX(Y)
            }
            
            
            _obstacleObject.gameObject.SetActive(true);
            //�����ɓ���̂�(�����������I�u�W�F�N�g,�����ʒu,��]�l)
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
