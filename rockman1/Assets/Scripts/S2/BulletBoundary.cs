using UnityEngine;
using System.Collections;

public class BulletBoundary : MonoBehaviour {

	public GameObject target;
	
	void Update()
	{
		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y, 0.0f);
	}
}
