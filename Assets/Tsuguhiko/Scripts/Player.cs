using UnityEngine;

/// <summary>
/// Playerのスクリプト
/// </summary>
public class Player : MonoBehaviour
{

	[SerializeField] float speed = 2; // スピード：Inspectorで指定

	float vx = 0;
	float vy = 0;

	bool leftFlag = false;

	Rigidbody2D rbody;

	void Start () 
	{
		rbody = GetComponent<Rigidbody2D>();
		
		rbody.constraints = RigidbodyConstraints2D.FreezeRotation; // 衝突時に回転させない
	}

	void Update () 
	{ 
		vx = 0;
		vy = 0;
		if(Input.GetKey("right")) // 右キーが押されたら
		{ 
			vx = speed; // 右に進む移動量を入れる
			leftFlag = false;
		}
		if(Input.GetKey("left")) // 左キーが押されたら
		{ 
			vx = -speed; // 左に進む移動量を入れる
			leftFlag = true;
		}
		if(Input.GetKey("up")) // 上キーが押されたら
		{ 
			vy = speed; // 上に進む移動量を入れる
		}
		if(Input.GetKey("down")) // 下キーが押されたら
		{ 
			vy = -speed; // 下に進む移動量を入れる
		}
	}
	void FixedUpdate() 
	{
		rbody.velocity = new Vector2(vx, vy); // 移動処理
											  
		this.GetComponent<SpriteRenderer>().flipX = leftFlag; // 左右の向きを変える
	}
}
