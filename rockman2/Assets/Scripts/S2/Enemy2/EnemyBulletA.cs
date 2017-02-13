using UnityEngine;
using System.Collections;

public class EnemyBulletA : MonoBehaviour {

	public float bulletspeed;
	Vector3 direction;
	
	void Awake()
	{
		direction = new Vector3 (-1.0f, -1.0f, 0);
	}
	
	void FixedUpdate()
	{
		transform.Translate (direction * bulletspeed);
	}
}
