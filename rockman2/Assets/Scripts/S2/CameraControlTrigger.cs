using UnityEngine;
using System.Collections;

public class CameraControlTrigger : MonoBehaviour {

	// Use this for initialization
	public int cameraTriggerNumber;

	void OnTriggerStay(Collider other)
	{
		if (other.tag=="Player") {
			CameraController.cameraNumber =cameraTriggerNumber;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
