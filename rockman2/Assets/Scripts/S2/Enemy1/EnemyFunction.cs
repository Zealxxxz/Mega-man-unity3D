using UnityEngine;
using System.Collections;

public class EnemyFunction : MonoBehaviour {

	public GameObject playerTrigger;
	public GameObject triggerA;
	public GameObject triggerB;
	public float speedNormal;
	public float speedCrazy;
	private float speed;
	private float turn=1;
	bool speedUpTrigger;
	bool turnTriggerA;
	bool turnTriggerB;
	bool state1control;
	public GameObject sfxController;

	Animator anim;

	void Awake()
	{
		speed = speedNormal;
		state1control = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag =="Bullet") {
			state1control =false;
			sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
			Invoke("state1Control",1);
		}
	}

	void FixedUpdate()
	{
		speedUpTrigger = playerTrigger.GetComponent<TriggerScript> ().Trigger;
		turnTriggerA = triggerA.GetComponent<TriggerScript> ().Trigger;
		turnTriggerB = triggerB.GetComponent<TriggerScript> ().Trigger;
		if (state1control) {
			State1();
		}
		else {
			State2();
		}

	}
	void State1()
	{
		GetComponent<Animator> ().Play ("Enemy1_idle");
		if (speedUpTrigger) {
			speed =speedCrazy;
		}
		if (!speedUpTrigger) {
			speed =speedNormal;
		}
		if (turnTriggerA) {
			turn =-1;
		}
		if (turnTriggerB) {
			turn =1;
		}
		transform.Translate (Vector3.right * speed*turn);
	}
	void State2()
	{
		GetComponent<Animator> ().Play ("Enemy1_Hurt");
	}
	void state1Control()
	{
		state1control =true;
	}
}
