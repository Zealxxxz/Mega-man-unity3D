using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject player;
	public GameObject CameraTrigger;
	public static int cameraNumber;
	public float CamerMoveSpeed;
	float cameraPX;
	float cameraPY;

	void Awake()
	{
		//cameraNumber = 0;
	}
	
	void FixedUpdate()
	{
		if (player.transform.position.x<=0) {
			cameraNumber =0;
		}
		float playerX = player.GetComponent<Transform> ().position.x;
		float playery = player.GetComponent<Transform> ().position.y;
		switch (cameraNumber) {
		case 0:State0();break;
		case 1:State1(playerX);break;
		case 2:State2(playerX);break;
		case 3:State3(playerX);break;
		case 4:State4(playerX);break;
		case 5:State5(playerX);break;
		case 6:State6(playerX);break;
		case 7:State7(playerX);break;
		case 8:State8(playerX);break;
		case 9:State9(playerX);break;
		case 10:State10(playerX);break;
		case 11:State11(playerX);break;
		case 12:State12(playerX);break;
		case 13:State13(playerX);break;
		case 14:State14(playerX);break;
		case 15:State15(playerX);break;
		case 16:State16(playerX);break;
		case 17:State17(playerX);break;
		default:break;
		}
	}

	void State0()
	{
		transform.position = new Vector3(0, 0.3f, -10f);
	}
	void State1(float playerX)
	{
		transform.position = new Vector3 (playerX, 0.3f, -10f);
	}
	void State2(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY<0.7f) {
			cameraPY=cameraPY+CamerMoveSpeed;
			transform.position = new Vector3 (playerX, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (playerX, 0.7f , -10f);
		}
	}
	void State3(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPX<13.087f) {
			print("ss");
			cameraPX=cameraPX+CamerMoveSpeed;
			transform.position = new Vector3 (cameraPX, 0.7f , -10f);
		}
		else {
			transform.position = new Vector3 (13.087f, 0.7f , -10f);
		}
	}
	void State4(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY>-0.892f) {
			cameraPY=cameraPY-CamerMoveSpeed;
			transform.position = new Vector3 (13.087f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (13.087f, -0.892f , -10f);
		}
	}
	void State5(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY>-2.401f) {
			cameraPY=cameraPY-CamerMoveSpeed;
			transform.position = new Vector3 (13.087f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (13.087f, -2.401f , -10f);
		}
	}
	void State6(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY>-3.841f) {
			cameraPY=cameraPY-CamerMoveSpeed;
			transform.position = new Vector3 (13.087f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (13.087f, -3.841f , -10f);
		}
	}
	void State7(float playerX)
	{
		transform.position = new Vector3 (playerX, -3.841f, -10f);
	}
	void State8(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPX<24.6f) {
			cameraPX=cameraPX+CamerMoveSpeed;
			transform.position = new Vector3 (cameraPX, -3.841f , -10f);
		}
		else {
			transform.position = new Vector3 (24.6f, -3.841f , -10f);
		}
	}
	void State9(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY<-2.26f) {
			cameraPY=cameraPY+CamerMoveSpeed;
			transform.position = new Vector3 (24.6f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (24.6f, -2.26f , -10f);
		}
	}
	void State10(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY<-0.88f) {
			cameraPY=cameraPY+CamerMoveSpeed;
			transform.position = new Vector3 (24.6f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (24.6f, -0.88f , -10f);
		}
	}
	void State11(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY<0.47f) {
			cameraPY=cameraPY+CamerMoveSpeed;
			transform.position = new Vector3 (24.6f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (24.6f, 0.47f , -10f);
		}
	}
	void State12(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY<1.65f) {
			cameraPY=cameraPY+CamerMoveSpeed;
			transform.position = new Vector3 (24.6f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (24.6f, 1.65f , -10f);
		}
	}
	void State13(float playerX)
	{
		transform.position = new Vector3 (playerX, 1.65f , -10f);
	}
	void State14(float playerX)
	{
		transform.position = new Vector3 (16.29f, 1.65f , -10f);
	}
	void State15(float playerX)
	{
		transform.position = new Vector3 (16.29f, 0.54f , -10f);
	}
	void State16(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY>0.46f) {
			cameraPY=cameraPY-CamerMoveSpeed;
			transform.position = new Vector3 (16.29f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (16.29f, 0.46f , -10f);
		}
	}
	void State17(float playerX)
	{
		cameraPX = transform.position.x;
		cameraPY = transform.position.y;
		if (cameraPY>-1.15f) {
			cameraPY=cameraPY-CamerMoveSpeed;
			transform.position = new Vector3 (16.29f, cameraPY , -10f);
		}
		else {
			transform.position = new Vector3 (16.29f, -1.15f , -10f);
		}
	}

}
