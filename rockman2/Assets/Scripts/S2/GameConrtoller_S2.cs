using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameConrtoller_S2 : MonoBehaviour {

	//开场响起音乐，死亡停止音乐，
	//显示Ready
	//开场画面功能，死亡重启功能
	public GameObject player;

	public GUIText ready;
	//public GUIText ScoreText;

	public AudioClip audioStage;
	public AudioClip audioBoss;
	public AudioClip audioClear;
	public AudioClip audioDie;

	private int score=0;

	bool isOnGround=false;
	bool active=false;
	bool isDead;

	public bool isInBossRomm =false;
	public bool isStageClear=false;
	float StageClearTimer=0;
	float BossRoomTimer=0;

	public GameObject HPfiller;

	public GameObject HPbar_MC;
	public GameObject HPtext;
	float HPvalue_MC;
	public GameObject scoreText;


	void Awake()
	{
		player.SetActive (false);
		GetComponent<AudioSource>().clip =audioStage;
		GetComponent<AudioSource> ().Play ();
		ready.enabled=true;

	}
	void FixedUpdate()
	{
		HPvalue_MC =player.GetComponent<PlayerControllerNew> ().HP;
		HPtext.GetComponent<UILabel>().text = HPvalue_MC + "";
		HPbar_MC.GetComponent<UISlider> ().sliderValue = HPvalue_MC/28;
		if (Time.timeSinceLevelLoad<2) {

		}
		if (Time.timeSinceLevelLoad>2&&Time.timeSinceLevelLoad<3) {
			ready.enabled=false;
			active=true;
			player.SetActive (active);
		}
		if (player.transform.position.y<=0&&active==true) {
			
			//播放开场动画
		}
		if (player.GetComponent<PlayerControllerNew>().HP<=0&&!isDead) {

			Dead();
		}

		//关卡结束
		if (isStageClear) {
			player.GetComponent<PlayerControllerNew>().anim.Play("MC_Idle");
			player.GetComponent<PlayerControllerNew>().enabled =false;
			StageClearTimer++;
			if (StageClearTimer<=100) {
				GetComponent<AudioSource>().clip =audioClear;
				GetComponent<AudioSource> ().Play ();
			}
			if (StageClearTimer>300) {
				CheckPointFunction.checkPointNumber =0;
				Application.LoadLevel(3);
			}
		}

		if (isInBossRomm) {
			BossRoomTimer++;
			if (BossRoomTimer==1) {
				GetComponent<AudioSource>().clip =audioBoss;
				GetComponent<AudioSource> ().Play ();
			}
		}

	}

	void Dead()
	{
		isDead = true;
		GetComponent<AudioSource> ().clip = audioDie;
		GetComponent<AudioSource> ().Play ();
		player.SetActive(false);
		Invoke ("LoadLevel", 1);
	}

	void LoadLevel()
	{
		Application.LoadLevel(2);
	}
	public void AddScore(int value)
	{
		score = score + value;
		//ScoreText.text = score.ToString ();
		scoreText.GetComponent<UILabel>().text = score + "";

	}


}
