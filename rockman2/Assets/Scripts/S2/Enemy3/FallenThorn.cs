using UnityEngine;
using System.Collections;

public class FallenThorn : MonoBehaviour {

	float timer;
	public float resetTime;
	public Vector3 kkk;
	public float fallenSpeed;
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		transform.Translate(Vector3.down*fallenSpeed);
		timer++;
		if (timer>=resetTime) {
			transform.position =kkk;
			timer =0;

		}
	}
}
