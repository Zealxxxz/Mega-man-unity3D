using UnityEngine;
using System.Collections;

public class BombTrigger : MonoBehaviour {

	public GameObject Cause;
	public bool Trigger;
	void OnTriggerEnter(Collider other)
	{
		
		if (other.gameObject==Cause) {
			Trigger =true;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.gameObject==Cause) {
			Trigger =true;
		}
	}
	void FixedUpdate()
	{
		//print (Trigger);
	}
}
