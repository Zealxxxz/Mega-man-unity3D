using UnityEngine;
using System.Collections;

public class MovingThorn : MonoBehaviour {

	public GameObject triggerA;
	public GameObject triggerB;
	public GameObject triggerPlayer;
	public float speed;
	private float turn=1;
	bool turnTriggerA;
	bool turnTriggerB;
	bool isTrigger;
	public Vector3 direction;

	void FixedUpdate()
	{
		isTrigger =triggerPlayer.GetComponent<TriggerScript> ().Trigger;
		turnTriggerA = triggerA.GetComponent<TriggerScript> ().Trigger;
		turnTriggerB = triggerB.GetComponent<TriggerScript> ().Trigger;
		if (turnTriggerA) {
			turn =-1;
		}
		if (turnTriggerB) {
			turn =1;
		}
		if (isTrigger) {
			transform.Translate (direction* speed*turn);
		}


	}
}
