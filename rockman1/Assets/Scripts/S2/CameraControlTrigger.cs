using UnityEngine;
using System.Collections;

public class CameraControlTrigger : MonoBehaviour {

	// Use this for initialization
	public int cameraTriggerNumber;
	GameObject mainCamera;

	void Awake () 
	{
		mainCamera = GameObject.Find ("Main Camera");
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag=="Player") {
			mainCamera.GetComponent<CameraController>().cameraNumber =cameraTriggerNumber;
		}
	}
	// Update is called once per frame
	void Update () {
	}
}
