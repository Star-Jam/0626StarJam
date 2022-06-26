using UnityEngine;

/// <summary>
/// Playerのスクリプト
/// </summary>
public class Player : MonoBehaviour
{

	[SerializeField] float _speed = 2; // スピード：Inspectorで指定

	float _vx = 0;
	float _vy = 0;

	bool _leftFlag = false;

	Rigidbody2D _rbody;

	void Start () 
	{
		_rbody = GetComponent<Rigidbody2D>();
		
		_rbody.constraints = RigidbodyConstraints2D.FreezeRotation; // 衝突時に回転させない
	}

	void Update () 
	{ 
		_vx = 0;
		_vy = 0;
		if(Input.GetKey("right")) // 右キーが押されたら
		{ 
			_vx = _speed; // 右に進む移動量を入れる
			_leftFlag = false;
		}
		if(Input.GetKey("left")) // 左キーが押されたら
		{ 
			_vx = -_speed; // 左に進む移動量を入れる
			_leftFlag = true;
		}
		if(Input.GetKey("up")) // 上キーが押されたら
		{ 
			_vy = _speed; // 上に進む移動量を入れる
		}
		if(Input.GetKey("down")) // 下キーが押されたら
		{ 
			_vy = -_speed; // 下に進む移動量を入れる
		}
	}
	void FixedUpdate() 
	{
		_rbody.velocity = new Vector2(_vx, _vy); // 移動処理
											  
		this.GetComponent<SpriteRenderer>().flipX = _leftFlag; // 左右の向きを変える
	}
}
