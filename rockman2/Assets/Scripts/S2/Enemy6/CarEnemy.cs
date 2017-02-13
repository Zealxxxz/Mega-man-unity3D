using UnityEngine;
using System.Collections;

public class CarEnemy : MonoBehaviour {

	public GameObject PlayerTrigger;
	public float moveSpeed;
	bool Trigger;
	public GameObject sfxController;

	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Bullet") {
			sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
			GetComponent<EnemyProperty>().TakeDamage();
		}
		if (other.tag=="Enemy") {
			print("true");
			sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
			Destroy(gameObject);
		} 
	}
	void FixedUpdate()
	{
		Trigger = PlayerTrigger.GetComponent<BombTrigger> ().Trigger;
		if (Trigger) {
			transform.Translate(Vector3.right*moveSpeed);
		}
	}
}
