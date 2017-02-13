using UnityEngine;
using System.Collections;

public class EnemyBulletB : MonoBehaviour {

	public float bulletspeed;
	Vector3 direction;
	
	void Awake()
	{
		direction = new Vector3 (-1.0f,0, 0);
	}
	
	void FixedUpdate()
	{
		transform.Translate (direction * bulletspeed);
	}
}
