using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

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
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject==Cause) {
			Trigger =false;
		}
	}
	void FixedUpdate()
	{
			//print (Trigger);
	}
}
