using UnityEngine;
using System.Collections;

public class DeadZoneFollow : MonoBehaviour {

	public GameObject owner;
	float PX;
	float PY;
	void FixedUpdate()
	{
		PX = owner.GetComponent<Transform> ().position.x;
		PY = owner.GetComponent<Transform> ().position.y;
		transform.position = new Vector3 (PX, PY, 0.0f);
	}

}
