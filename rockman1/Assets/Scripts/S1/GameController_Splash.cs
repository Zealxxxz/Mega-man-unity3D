using UnityEngine;
using System.Collections;

public class GameController_Splash : MonoBehaviour {

	GameObject camera0;
	GameObject camera1;
	GameObject mc;
	//For MC anim
	public float movespeed;
	public float upspeed;
	public AudioSource playerAudio;
	Animator animMC;

	float timer1=0;
	float timer2=0;

	int state =1;
	bool animSwitch;
	
	void Awake()
	{
		camera0 = GameObject.Find ("Camera");
		camera1 = GameObject.Find ("Camera1");
		mc = GameObject.Find ("Player");
		animMC = mc.GetComponentInChildren<Animator> ();

	}
	void FixedUpdate()
	{

		if (state==1) {
			Stage1();
		}
		if (state==2) {
			Stage2();

		}
	}
	void Stage1()
	{
		camera0.SetActive(true);
		camera1.SetActive(false);
		timer2 = 0;
		timer1++;
		if (timer1<100) {
			animSwitch =true;
			mc.transform.Translate (Vector3.right * movespeed);
		}
		if (timer1>=100) {
			animSwitch =false;
			if (!playerAudio.isPlaying) {
				playerAudio.Play();
			}
			mc.transform.Translate (Vector3.up * upspeed);
		}
		animMC.SetBool ("Switch", animSwitch);
		if (mc.transform.position.y>2) {
				state =2;
		}
		if (Input.GetKeyDown("j")) {
			Invoke("SetState2",0.5f);
		}
	}
	void Stage2()
	{
		camera0.SetActive(false);
		camera1.SetActive(true);
		if (!GetComponent<AudioSource>().isPlaying) {
			GetComponent<AudioSource>().Play ();
		}
		mc.transform.position = new Vector3 (0, 0, 0);
		timer1 = 0;

		timer2++;
		if (Input.GetKey("j")) {
			Invoke("LoadGame",1);
		}
		if (timer2==1000) {
			state =1;
		}
	}

	void SetState2()
	{
		state = 2;
		print("B");
	}

	void LoadGame()
	{
		Application.LoadLevel(1);
	}
}
