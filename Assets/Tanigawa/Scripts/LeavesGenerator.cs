using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGenerator : MonoBehaviour
{
    public Transform _Spawner;
    public List<GameObject> _leafPrefab;

    [Header("�X�|�[���Ԋu")]
    public float _spawninterval = 5f;
    private float _passedtime = 3f;

    // Update is called once per frame
    void Update()
    {//�X�|�[���Ԋu���Ƃɗt�I�u�W�F�N�g���X�|�[������
        _passedtime += Time.deltaTime;
        if (_passedtime > _spawninterval)
        {
            Spawn();
            _passedtime = 0;
        }
    }
    /// <summary>
    /// �t�I�u�W�F�N�g���X�|�[�������鏈��
    /// </summary>
    private void Spawn()
    {
        int leafindex = Random.Range(0, _leafPrefab.Count);//��������
        GameObject leaf = _leafPrefab[leafindex];//�����œ���Index�̃v���n�u��leaf�ɓ����

        Instantiate(leaf, _Spawner);// �v���n�u����w��̗t�I�u�W�F�N�g����
    }
}
