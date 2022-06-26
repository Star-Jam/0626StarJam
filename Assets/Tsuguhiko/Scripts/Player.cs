using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Playerのスクリプト
/// </summary>
public class Player : MonoBehaviour
{
	[SerializeField] HitCount hitCount;

	[SerializeField] Image[] _lifeImages;


	[SerializeField] Text _countText;
	[SerializeField] float _speed = 2; // スピード：Inspectorで指定

	float _vx = 0;
	float _vy = 0;

	bool _leftFlag = false;

	Rigidbody2D _rbody;

	public int _socre = 0;

	void Start () 
	{
		hitCount = HitCount.hit0;

		_rbody = GetComponent<Rigidbody2D>();
		
		_rbody.constraints = RigidbodyConstraints2D.FreezeRotation; // 衝突時に回転させない

		_countText.text = _socre.ToString();
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

	// 葉っぱに触れたら
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Leaf"))
        {
			Destroy(col.gameObject);

			AddScore();
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && hitCount == HitCount.hit0)
        {
			_lifeImages[2].enabled = false;

			hitCount = HitCount.hit1;
		}
		else if (col.gameObject.tag == "Enemy" && hitCount == HitCount.hit1)
        {
			_lifeImages[1].enabled = false;

			hitCount = HitCount.hit2;
		}
		else if (col.gameObject.tag == "Enemy" && hitCount == HitCount.hit2)
		{
			_lifeImages[0].enabled = false;

			hitCount = HitCount.hit0;

			//SceneManager.LoadScene("GameOver");
		}
	}

    void AddScore()
    {
		_socre++;

		_countText.text = _socre.ToString();
	}
}
enum HitCount
{
	hit0,
	hit1,
	hit2,
	hit3
}