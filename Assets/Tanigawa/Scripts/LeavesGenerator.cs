using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavesGenerator : MonoBehaviour
{
    public Transform _Spawner;
    public List<GameObject> _leafPrefab;

    [Header("スポーン間隔")]
    public float _spawninterval = 5f;
    private float _passedtime = 3f;

    // Update is called once per frame
    void Update()
    {//スポーン間隔ごとに葉オブジェクトをスポーンする
        _passedtime += Time.deltaTime;
        if (_passedtime > _spawninterval)
        {
            Spawn();
            _passedtime = 0;
        }
    }
    /// <summary>
    /// 葉オブジェクトをスポーンさせる処理
    /// </summary>
    private void Spawn()
    {
        int leafindex = Random.Range(0, _leafPrefab.Count);//乱数生成
        GameObject leaf = _leafPrefab[leafindex];//乱数で得たIndexのプレハブをleafに入れる

        Instantiate(leaf, _Spawner);// プレハブから指定の葉オブジェクト生成
    }
}
