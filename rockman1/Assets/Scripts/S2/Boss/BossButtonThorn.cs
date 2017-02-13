using UnityEngine;
using System.Collections;

public class BossButtonThorn : MonoBehaviour {

	public GameObject triggerA;
	public GameObject triggerB;
	public float speed;
	private float turn=1;
	bool turnTriggerA;
	bool turnTriggerB;
	public bool Switch =true;
	
	void FixedUpdate()
	{
		turnTriggerA = triggerA.GetComponent<TriggerScript> ().Trigger;
		turnTriggerB = triggerB.GetComponent<TriggerScript> ().Trigger;
		if (Switch) {
			transform.Translate (Vector3.up * speed*turn);
		}
		if (turnTriggerA) {
			turn =-1;
			speed =0.01f;
		}
		if (turnTriggerB) {
			turn =1;
			speed =0.02f;
			Switch =false;
		}
	}
}
