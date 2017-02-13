using UnityEngine;
using System.Collections;

public class BossBulletFuction : MonoBehaviour {

	public float bulletspeed;
	void OnTriggerExit(Collider other)
	{
		if (other.tag=="BulletBoundary") {
			Destroy (gameObject);
		}
	}
	
	void FixedUpdate()
	{
		GetComponent<Animator> ().Play ("BulletFly");
		transform.Translate (Vector3.left * bulletspeed);
	}
}
