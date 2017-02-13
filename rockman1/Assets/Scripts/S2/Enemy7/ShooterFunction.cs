using UnityEngine;
using System.Collections;

public class ShooterFunction : MonoBehaviour {

	public GameObject playerTrigger;
	public GameObject bullet;
	public GameObject Player;
	public GameObject sfxController;

	bool canAttack;
	bool activeTrigger;
	float actionTimer;
	
	void Awake()
	{
		actionTimer =0;
		canAttack = false;
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Bullet") {
			if (canAttack) {
				sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
				GetComponent<EnemyProperty>().TakeDamage();
			}
			if (!canAttack) {
				sfxController.GetComponent<SFXcontroller>().SoundAttackFall();
			}
		}
	}
	
	void FixedUpdate()
	{
		activeTrigger = playerTrigger.GetComponent<TriggerScript> ().Trigger;
		if (activeTrigger) {
			actionTimer++;
		}
		if (actionTimer<80) {
			canAttack =false;
			GetComponent<Animator>().Play("Shooter_Idle");
		}
		if (actionTimer>80&&actionTimer<200) 
		{
			canAttack =true;
			if (actionTimer<100) {
				GetComponent<Animator>().Play("Shooter_Start");
			}
			if (actionTimer>=100) {
				GetComponent<Animator>().Play("Shooter_Shoot");
				if (actionTimer==120) {
					sfxController.GetComponent<SFXcontroller>().SoundAttackShoot();
					Instantiate(bullet, transform.position,transform.rotation);
				}
				if (actionTimer==160) {
					sfxController.GetComponent<SFXcontroller>().SoundAttackShoot();
					Instantiate(bullet, transform.position,transform.rotation);
				}
			}
		}
		if (actionTimer>=200) 
		{
			actionTimer =0;
		}
	}
}
