using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossFunctionNew : MonoBehaviour {

	public bool ActiveSwitch=false;

	float HP=1;
	public Slider HPslider;
	public GameObject Slider;
	Animator anim;
	bool immune=true;
	float immueTimer =1;
	bool hurtTrigger=false;

	int stateNumber =1;
	int AIstateNumber=1;

	float state1Timer;
	int AINumber =1;
	float AItimer;
	int AITransferNumber=1;

	float moveSpeed =0.013f;
	float jumpSpeed =0.02f;
	public GameObject bullet;
	bool isDeath;
	float bossPositionX;
	float bossPositionY;

	public GameConrtoller_S2 gameController_S2;
	GameObject sfxController;

	public GameObject explosion;
	public int value;


	public GameObject Thorn1;
	public GameObject Thorn2;
	public GameObject Thorn3;
	public GameObject Thorn4;
	public GameObject ThornL;
	public GameObject ThornR;
	public GameObject ThornLP;
	public GameObject ThornRP;
	float ultTimer=0;

	public Transform bulletPosition;

	public GameObject HPfiller;
	public GameObject HPBar_Boss;

	void Awake()
	{
		sfxController = GameObject.Find ("SFXController");
		anim =GetComponentInChildren<Animator> ();
		Slider.SetActive (false);
	}
	void OnTriggerEnter(Collider other)
	{
		if (immune==false) {
			if (other.tag=="Bullet") {
				sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
				HP =HP-2;
			}
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag=="Bullet") {
			hurtTrigger =true;
		}
	}
	void OnTriggerExit(Collider other)
	{
	}
	void ImmueFunction()
	{
		if (immune ==false) {
			if (hurtTrigger) {
				immune =true;
			}
		}
		if (immune==true) {
			immueTimer++;
		}
		if (immueTimer==80) {
			immune=false;
			hurtTrigger =false;
			immueTimer =1;
		}
		if (immueTimer%4==0) {

			GetComponentInChildren<SpriteRenderer> ().color = new Color (225f, 225f, 225f, 0f);
		}
		else {
			GetComponentInChildren<SpriteRenderer> ().color = new Color (225f, 225f, 225f, 225f);
		}

	}
	void FixedUpdate()
	{
		HPBar_Boss.GetComponent<UISlider> ().sliderValue = HP/28;
		if (ActiveSwitch) {
			switch (stateNumber) {
			case 1: State1();break;
			case 2: State2();break;
			default:break;
			}
		}
	}

	void State1()
	{
		state1Timer++;
		HPBar_Boss.SetActive (true);
		if (HP<28) {
			sfxController.GetComponent<SFXcontroller>().SoundAddHP();
			if (state1Timer % 5==0) {
				HP++;
			}
			anim.Play("Boss_ult");
		}
		if (HP==28) {
			anim.Play("Boss_Idle");
		}
		if (state1Timer>=200) {
			state1Timer =1;
			stateNumber =2;
			immune = false;
		}
	}

	void State2()
	{
		print(AIstateNumber);
		if (HP>=0) {
			ImmueFunction();
		}
		//免疫
		//AI
		bossPositionX = transform.position.x;
		bossPositionY = transform.position.y;

		switch (AIstateNumber) {
		case 1: AIstate1();break;
		case 2: AIstate2();break;
		case 3: AIstate3();break;
		case 4: AIstate2();break;
		case 5: AIstate1();break;
		case 6: AIstate4();break;
		case 7: AIstateNumber=1;break;
		default:break;
		}

		if (HP<=0) {
			HPfiller.SetActive(false);
			Death();
		}
	}

	void AIPorpertyReset()
	{
		AItimer = 0;
		AINumber++;
		if (AItimer==0) {
			if (bossPositionX==17.2f) {
				ActionRotate1();
			}
			if (bossPositionX==15.4f) {
				ActionRotate2();
			}
		}
	}
	void AIStatePorpertyReset()
	{
		AINumber = 1;
		AIstateNumber++;
	}

	void AIstate1()
	{
		switch (AINumber) {
		case 1: AI01();break;
		case 2: AI02();break;
		case 3: AI04(16.7f);break;
		case 4: AI04(16.3f);break;
		case 5: AI04(15.9f);break;
		case 6: AI04(15.4f);break;
		case 7: AIStatePorpertyReset();break;
		default:break;
		}
	}
	void AIstate2()
	{
		switch (AINumber) {
		case 1: AI01();break;
		case 2: AI02();break;
		case 3: AI05(15.9f);break;
		case 4: AI05(16.3f);break;
		case 5: AI05(16.7f);break;
		case 6: AI05(17.2f);break;
		case 7: AIStatePorpertyReset();break;
		default:break;
		}
	}
	void AIstate3()
	{
		switch (AINumber) {
		case 1: AI04(16.7f);break;
		case 2: AI04(16.3f);break;
		case 3: AI03();break;
		case 4: AI04(15.9f);break;
		case 5: AI04(15.4f);break;
		case 6: AIStatePorpertyReset();break;
		default:break;
		}
	}
	void AIstate4()
	{
		switch (AINumber) {
		case 1: AI05(15.9f);break;
		case 2: AI05(16.3f);break;
		case 3: AI03();break;
		case 4: AI05(16.7f);break;
		case 5: AI05(17.2f);break;
		case 6: AIStatePorpertyReset();break;
		default:break;
		}
	}

	void AI01()
	{//前后射击1
		AItimer++;
		if (AItimer>=20&&AItimer<30) {
			ActionShootAnim ();
		}
		if (AItimer==25) {
			ActionShoot ();
		}
		if (AItimer>40&&AItimer<=50) {
			ActionIdle();
		}
		if (AItimer>50&&AItimer<75) {
			ActionMove();
		}
		if (AItimer>=75&&AItimer<85) {
			ActionShootAnim ();
		}
		if (AItimer==80) {
			ActionShoot ();
		}
		if (AItimer>85&&AItimer<105) {
			ActionIdle();
		}
		if (AItimer>95&&AItimer<120) {
			if (bossPositionX<16.3) {
				ActionRotate1();
			}
			if (bossPositionX>16.3) {
				ActionRotate2();
			}
			ActionMove();
		}
		if (AItimer==120) {
			if (bossPositionX<16.3) {
				ActionRotate2();
			}
			if (bossPositionX>16.3) {
				ActionRotate1();
			}
		}
		if (AItimer>120&&AItimer<130) {
			ActionShootAnim ();
		}
		if (AItimer==125) {
			ActionShoot ();
		}
		if (AItimer==130) {
			ActionIdle();
		}
		if (AItimer==140) {
			AIPorpertyReset();
		}
	}
	void AI02()
	{
		//跳上ult1跳下
		AItimer++;
		if (AItimer<80) {
			ActionJumpUp1 ();
		}
		if (AItimer==150) {
			ultTimer =0;
		}
		if (AItimer>=80&&AItimer<150) {
			Ult1();
		}
		if (AItimer>=150&&AItimer<250) {
			ActionJumpDown();
		}
		if (AItimer==250) {
			AIPorpertyReset();
		}
	}
	void AI03()
	{
		AItimer++;
		if (AItimer<100) {
			ActionJumpUp2 ();
		}
		if (AItimer==100) {
			Ult2();
		}
		if (AItimer>=150) {
			ActionJumpDown();
		}
		if (AItimer>=200) {
			AIPorpertyReset();
		}
		//跳上ult2跳下
	}
	void AI04(float stayPosition)
	{
		//从左往右跑
		if (bossPositionX>stayPosition) {
			anim.Play("Boss_Move");
			bossPositionX=bossPositionX-moveSpeed;
			transform.position = new Vector3 (bossPositionX, -1.395f , 0.0f);
		}
		else {
			transform.position =new Vector3(stayPosition,-1.395f,0.0f);
			anim.Play("Boss_Idle");
		}
		if (bossPositionX==stayPosition) {
			ActionShoot();
			ActionShootAnim();
			AIPorpertyReset();
		}
	}
	void AI05(float stayPosition)
	{
		//从右跑到左
		if (bossPositionX<stayPosition) {
			anim.Play("Boss_Move");
			bossPositionX=bossPositionX+moveSpeed;
			transform.position = new Vector3 (bossPositionX, -1.395f , 0.0f);
		}
		else {
			transform.position =new Vector3(stayPosition,-1.395f,0.0f);
			anim.Play("Boss_Idle");
		}
		if (bossPositionX==stayPosition) {
			ActionShoot();
			ActionShootAnim();
			AIPorpertyReset();
		}
	}

	void ActionMove()
	{
		anim.Play("Boss_Move");
		transform.Translate (Vector3.left * moveSpeed);
	}
	void ActionIdle()
	{
		anim.Play("Boss_Idle");
	}
	void ActionRotate1()
	{
		transform.rotation =Quaternion.AngleAxis(0,Vector3.up);
	}
	void ActionRotate2()
	{
		transform.rotation =Quaternion.AngleAxis(180,Vector3.up);
	}
	void ActionJumpUp1()
	{
		if (bossPositionY<-1.031f) {
			anim.Play("Boss_Jump");
			bossPositionY=bossPositionY+jumpSpeed;
			transform.position = new Vector3 (bossPositionX, bossPositionY , 0.0f);
		}
		else {
			anim.Play("Boss_Idle");
			transform.position =new Vector3(bossPositionX,-1.031f,0.0f);
		}
	}
	void ActionJumpUp2()
	{
		if (bossPositionY<-0.699f) {
			anim.Play("Boss_Jump");
			bossPositionY=bossPositionY+jumpSpeed;
			transform.position = new Vector3 (bossPositionX, bossPositionY , 0.0f);
		}
		else {
			anim.Play("Boss_Idle");
			transform.position =new Vector3(bossPositionX,-0.699f,0.0f);
		}
	}
	void ActionJumpDown()
	{
		if (bossPositionY>-1.395252f) {
			bossPositionY=bossPositionY-jumpSpeed;
			anim.Play("Boss_Jump");
			transform.position = new Vector3 (bossPositionX, bossPositionY , 0.0f);
		}
		else {
			anim.Play("Boss_Idle");
			transform.position =new Vector3(bossPositionX,-1.395252f,0.0f);
		}
	}
	void ActionShootAnim()
	{
		anim.Play("Boss_Shoot");
	}
	void ActionShoot()
	{

		Instantiate(bullet,bulletPosition.position,bulletPosition.rotation);
	}
	void Ult1()
	{
		ultTimer++;
		if (AIstateNumber==1||AIstateNumber==5) {
			if (ultTimer<=10) {
				Thorn1.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>5&&ultTimer<=15) {
				Thorn2.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>10&&ultTimer<=20) {
				Thorn3.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>15&&ultTimer<=25) {
				Thorn4.GetComponent<BossButtonThorn> ().Switch = true;
			}
		}
		if (AIstateNumber==2||AIstateNumber==4) {
			if (ultTimer<=10) {
				Thorn4.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>5&&ultTimer<=15) {
				Thorn3.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>10&&ultTimer<=20) {
				Thorn2.GetComponent<BossButtonThorn> ().Switch = true;
			}
			if (ultTimer>15&&ultTimer<=25) {
				Thorn1.GetComponent<BossButtonThorn> ().Switch = true;
			}
		}
		anim.Play("Boss_ult");
	}
	void Ult2()
	{
		anim.Play("Boss_ult");
		if (AIstateNumber==3) {
			Instantiate (ThornL,ThornLP.transform.position,ThornLP.transform.rotation);
		}
		if (AIstateNumber==6) {
			Instantiate (ThornR,ThornRP.transform.position,ThornRP.transform.rotation);
		}

	}

	void Death()
	{
		isDeath = true;
		sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
		gameController_S2.AddScore (value);
		gameController_S2.isStageClear = true;
		if (isDeath) {
			DeathAnim();
		}
		Destroy (gameObject);
	}
	void DeathAnim()
	{
		isDeath = false;
		Instantiate(explosion, transform.position, transform.rotation);
		Invoke ("Dispeear", 0.3f);
	}
	void Dispear()
	{
		Destroy (explosion);
	}

}
