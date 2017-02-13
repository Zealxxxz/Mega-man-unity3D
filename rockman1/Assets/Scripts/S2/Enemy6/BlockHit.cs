using UnityEngine;
using System.Collections;

public class BlockHit : MonoBehaviour {

	public GameObject Owner;
	public GameObject sfxController;

	void Awake()
	{
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Bullet") {
			sfxController.GetComponent<SFXcontroller>().SoundAttackFall();
		}
	}
	void FixedUpdate()
	{
		if (Owner.GetComponent<EnemyProperty>().HP>=0) {
			transform.position = Owner.GetComponent<Transform> ().position;
		}

		if (Owner.GetComponent<EnemyProperty>().HP<=0) {
			Destroy(gameObject);
		}
	}
}
