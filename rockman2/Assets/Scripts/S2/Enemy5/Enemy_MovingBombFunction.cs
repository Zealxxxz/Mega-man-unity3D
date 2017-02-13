using UnityEngine;
using System.Collections;

public class Enemy_MovingBombFunction : MonoBehaviour {

	public float moveSpeed;
	public GameObject PlayerTrigger;
	bool Trigger;
	public GameObject sfxController;

	void Awake()
	{
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Bullet") {
			GetComponent<EnemyProperty>().TakeDamage();
			sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
		}
	}

	void FixedUpdate () {
		Trigger = PlayerTrigger.GetComponent<BombTrigger> ().Trigger;

		if (Trigger) {
			transform.Translate(-moveSpeed,moveSpeed*Mathf.Sin(transform.position.x*4f),0.0f);
		}
	}
}
