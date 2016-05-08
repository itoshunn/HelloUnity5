using UnityEngine;
using System.Collections;

public class GravityController : MonoBehaviour {

	const float Gravity = 9.81f;		// 重力加速度
	public float gravityScale = 1.0f;	// 重力スケール
	
	// Update is called once per frame
	void Update () {
	
		Vector3 vector = new Vector3();
		
		// UnityEditer
		if(Application.isEditor)
		{
			// カーソルキー入力の取得
			// x, z 軸
			vector.x = Input.GetAxis("Horizontal");
			vector.z = Input.GetAxis("Vertical"); 
			
			// 高さ方向（Y軸）
			if (Input.GetKey("z"))
			{
				vector.y = 1.0f;
			}
			else
			{
				vector.y = -1.0f;	
			}
		}
		// 他のプラットフォーム
		else
		{
			// 加速度センサーの入力をマッピングする
			vector.x = Input.acceleration.x;
			vector.y = Input.acceleration.y;
			vector.z = Input.acceleration.z;	
		}
		
		// シーンに対する重力を入力に合わせて変化させる
		Physics.gravity = Gravity * vector.normalized * gravityScale;
	}
}
