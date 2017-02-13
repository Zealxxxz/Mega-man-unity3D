using UnityEngine;
using System.Collections;

public class CheckPointFunction : MonoBehaviour {

	public static int checkPointNumber =0;
	public GameObject player;
	public GameObject camera;
	Vector3 checkpoint0_player =new Vector3(0.0f,2.0f,0.0f);
	Vector3 checkpoint0_camera =new Vector3(0.0f,0.3f,-10.0f);
	Vector3 checkpoint1_player =new Vector3(14.94f,-1.7f,0.0f);
	Vector3 checkpoint1_camera =new Vector3(14.94f,-3.841f,-10.0f);
	Vector3 checkpoint2_player =new Vector3(24.6f,13.2f,0.0f);
	Vector3 checkpoint2_camera =new Vector3(24.6f,1.65f,-10.0f);
	void Awake()
	{
		switch (checkPointNumber) {
		case 0://player.transform.position =checkpoint0_player; 
			camera.transform.position =checkpoint0_camera; break;
		case 1:player.transform.position =checkpoint1_player; camera.transform.position =checkpoint1_camera; break;
		case 2:player.transform.position =checkpoint2_player; camera.transform.position =checkpoint2_camera; break;
		default:
			break;
		}
	}

}
