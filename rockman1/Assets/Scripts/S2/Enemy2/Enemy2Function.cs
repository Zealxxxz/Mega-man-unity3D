using UnityEngine;
using System.Collections;

public class Enemy2Function : MonoBehaviour {

	public GameObject playerTrigger;
	bool activeTrigger;
	float actionTimer;
	public GameObject bulletA;
	public GameObject bulletB;
	public GameObject bulletC;
	public GameObject Player;

	bool canAttack;
	public bool isFront;

	public GameObject sfxController;

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
		if (Player.transform.position.x>=transform.position.x) {
			isFront =true;
			transform.rotation =Quaternion.AngleAxis(180,Vector3.up);
		}
		if (Player.transform.position.x<transform.position.x) {
			isFront =false;
			transform.rotation =Quaternion.AngleAxis(0,Vector3.up);
		}
		activeTrigger = playerTrigger.GetComponent<TriggerScript> ().Trigger;
		if (activeTrigger) {
			actionTimer++;
		}
		if (!activeTrigger) {
			actionTimer =0;
			canAttack =false;
		}
		if (actionTimer==30) {
			Instantiate(bulletA, transform.position,transform.rotation);
			Instantiate(bulletB, transform.position,transform.rotation);
			Instantiate(bulletC, transform.position,transform.rotation);
		}
		if (actionTimer<50&&actionTimer>0) {

			canAttack =true;
		}
		if (actionTimer>50&&actionTimer<100) {

			canAttack =false;
		}
		if (actionTimer>=100) {
			actionTimer =0;
		}
		if (canAttack) {
			GetComponent<Animator>().Play("EM2Attacking");
		}
		if (!canAttack) {
			GetComponent<Animator>().Play("EM2def");
		}
	}
}
