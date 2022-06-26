using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
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
            _spriteRenderer.sprite = _obstacle[_obstacleNumber].Sprite;//�X�v���C�g��ύX
            _obstacleController.ChangeDamege(_obstacle[_obstacleNumber].Damege);//�_���[�W��ύX
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
        public Sprite Sprite => _sprite;

        [SerializeField]
        [Header("��Q���̖��O")]
        string _obstacleName;

        [SerializeField]
        [Header("�v���C���[�̎c�@�����炷��")]
        int _damege;

        [SerializeField]
        [Header("�X�s�[�h")]
        float _speed;

        [SerializeField]
        [Header("��Q���̃X�v���C�g")]
        Sprite _sprite;
    }
}
