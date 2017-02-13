using UnityEngine;
using System.Collections;

public class CheckPointTrigger : MonoBehaviour {

	public int checkNumber;
	public int cameraNumber;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Player") {
			CheckPointFunction.checkPointNumber =checkNumber;
			CameraController.cameraNumber =cameraNumber;
		}
	}
}
