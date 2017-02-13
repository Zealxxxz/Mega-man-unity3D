using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {

	public GameObject triggerA;
	public GameObject triggerB;
	public float speed;
	private float turn=1;
	bool turnTriggerA;
	bool turnTriggerB;
	
	void FixedUpdate()
	{
		turnTriggerA = triggerA.GetComponent<TriggerScript> ().Trigger;
		turnTriggerB = triggerB.GetComponent<TriggerScript> ().Trigger;
		if (turnTriggerA) {
			turn =-1;
		}
		if (turnTriggerB) {
			turn =1;
		}
		transform.Translate (Vector3.up * speed*turn);
	}
}
