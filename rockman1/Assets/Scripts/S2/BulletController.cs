using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	public float bulletspeed;

	//设置速度，检测碰撞，自我销毁,
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Enemy") {
			Destroy (gameObject);
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag=="BulletBoundary") {
			Destroy (gameObject);
		}
	}

	void FixedUpdate()
	{
		transform.Translate (Vector3.right * bulletspeed);
	}

}
