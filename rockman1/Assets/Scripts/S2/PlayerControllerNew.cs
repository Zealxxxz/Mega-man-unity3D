using UnityEngine;
using System.Collections;

public class PlayerControllerNew : MonoBehaviour {

	//Property
	public int HP;
	public float moveSpeed;
	public float jumpSpeed;
	public float jumpTimeLimit;
	//For ShootPoistion -----------------------------------
	public Transform gunground;
	public Transform gunjump;
	public Transform gunladder;
	//For ShootControll
	public float shootInterval;
	private float shootTimer;
	private bool shootUpLimit;
	public GameObject bullet;
	//For hurt
	private int damage;
	private bool immune;
	private float hurtTimer;
	private bool hurtTrigger;
	private bool hurtAction;
	Transform attackerTransform;
	//For anim
	public Animator anim;
	//For audio
	public AudioClip audioshoot;
	public AudioClip audiojump;
	public AudioClip audiohurt;
	private float shootTimer2;
	//For StateControll --------------------------------
	private bool on_ground;
	private bool in_air;
	private bool on_climbState;
	private bool jumpTrigger;
	private bool ladderTrigger;
	private bool isOnGroundStay;

	private Vector3 LadderPosition;//获取梯子位置
	private Vector3 groundPosition;
	private bool getHurt;
	//For PlayerHealth
	
	void Awake()
	{
		HP = 28;
		anim = GetComponentInChildren<Animator> ();
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Ground") {
			GetComponent<Rigidbody>().velocity =new Vector3(0,0,0);
			in_air =false;
			on_ground=true;
			groundPosition =other.transform.position;
		}
		if (other.tag=="Ladder") {
			ladderTrigger =true;
			LadderPosition =other.transform.position;
		}

		if (other.tag=="Enemy") {
			damage =other.GetComponent<EnemyDamage>().damage;
		}
	}
	void OnTriggerStay(Collider other)
	{
		if (other.tag=="Ground") {
			in_air =false;
			on_ground=true;
		}
		if (other.tag=="Enemy") {
			hurtTrigger =true;
			attackerTransform =other.transform;
		}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.tag=="Ground") {
			in_air =true;
			on_ground=false;
		}
		if (other.tag=="Ladder") {
			ladderTrigger =false;
		}
		if (other.tag=="Enemy") {
			hurtTrigger =false;
		}
	}

	void FixedUpdate()
	{
		//print (GetComponent<Rigidbody>().velocity);
		//print (jumpTrigger);
		AnimationController ();
		AudioController ();
		if (HP>0) {
			ClimbStateController();
			HurtStateController();
			ShootStateController();
			MoveMentController();
		}
		else {
			//死亡功能
		}

	}

	void HurtStateController()
	{
		if (immune ==false) {
			if (hurtTrigger) {
				immune =true;
				HP =HP-damage;
				hurtTimer =0;
			}
		}
		if (immune==true) {
			hurtAction =true;
			hurtTimer++;
		}
		if (hurtTimer>=15) {
			hurtAction=false;
		}
		if (hurtTimer==100) {
			immune=false;
		}
		
	}//伤害控制器
	void JumpStateController()
	{
		jumpTrigger = false;
	}
	void ClimbStateController()
	{
		//在空中爬，地面往上爬，地面往下爬
		if (ladderTrigger) {
			if (in_air) {
				if (Input.GetKey ("w") || Input.GetKey ("s")) {
					on_climbState = true;
				}
			}
			if (on_ground) {
				if (LadderPosition.y>groundPosition.y) {
					if (Input.GetKey("w")) {
						on_climbState =true;
					}
					if (Input.GetKey("s")) {
						on_climbState =false;
					}
				}
				if (LadderPosition.y<groundPosition.y) {
					if (Input.GetKey("w")) {
						transform.position =new Vector3(transform.position.x,groundPosition.y+0.2f,0);
						on_climbState =false;
					}
					if (Input.GetKey("s")) {
						transform.position =new Vector3(transform.position.x,groundPosition.y,0);
						on_climbState =true;
					}
				}
			}
		}
		else {
			on_climbState =false;
		}
		if (on_climbState) {
			if (Input.GetKey("k")) {
				on_climbState =false;
			}
		}
	}//
	void ShootStateController()
	{
		int bullerNumber = 0;
		GameObject [] bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		foreach (GameObject item in bullets) {
			bullerNumber++;
		}
		if (bullerNumber<3) {
			shootUpLimit =false;
		}
		else {
			shootUpLimit =true;
		}
	}
	void MoveMentController()
	{	//在受伤状态下的反应
		if (hurtAction) {
			GetComponent<Rigidbody>().Sleep();
			if (attackerTransform.position.x>=transform.position.x) {
				transform.Translate(-Vector3.right*moveSpeed);
			}
			else {
				transform.Translate(-Vector3.right*moveSpeed);
			}
		}
		//正常状态下下的反应
		else {
			GetComponent<Rigidbody>().WakeUp();
			//在攀爬状态下的按键反应
			if (on_climbState) {
				GetComponent<Rigidbody> ().useGravity = false;
				GetComponent<Rigidbody>().velocity =new Vector3(0,0,0);
				transform.position =new Vector3(LadderPosition.x,transform.position.y,0);
				if (Input.GetKey("a")) {
					transform.rotation =Quaternion.AngleAxis(180,Vector3.up);
				}
				if (Input.GetKey("d")) {
					transform.rotation =Quaternion.AngleAxis(0,Vector3.up);
				}
				if (Input.GetKey("j")) {
					if (Time.time>shootTimer&&shootUpLimit==false) {
						shootTimer =Time.time+shootInterval;
						GetComponent<AudioSource>().clip = audioshoot;
						GetComponent<AudioSource>().Play();
						Instantiate(bullet, gunladder.position,gunladder.rotation);
					}
				}
				else {
					if (Input.GetKey("w")) {
						transform.Translate(Vector3.up*moveSpeed);
					}
					if (Input.GetKey("s")) {
						transform.Translate (-Vector3.up * moveSpeed);
					}
				}
			}
			//在陆地状态下的按键反应
			else 
			{
				GetComponent<Rigidbody> ().useGravity = true;
				if (Input.GetKey("a")) {
					transform.rotation =Quaternion.AngleAxis(180,Vector3.up);
					transform.Translate(Vector3.right*moveSpeed);
				}
				if (Input.GetKey("d")) {
					transform.rotation =Quaternion.AngleAxis(0,Vector3.up);
					transform.Translate(Vector3.right*moveSpeed);
				}
				if (on_ground) {
					jumpTrigger =true;
					if (Input.GetKeyDown("k")&&on_ground) {
						GetComponent<Rigidbody>().velocity =new Vector3(0,0,0);
					}
				}
				if (in_air) {
					Invoke("JumpStateController",jumpTimeLimit);
				}
				if (jumpTrigger) {
					if (Input.GetKey("k")) {

						GetComponent<Rigidbody> ().AddForce (0.0f, jumpSpeed, 0.0f);
					}
				}

				if (Input.GetKey("j")) {
					if (Time.time>shootTimer&&shootUpLimit==false) {
						shootTimer =Time.time+shootInterval;
						GetComponent<AudioSource>().clip = audioshoot;
						GetComponent<AudioSource>().Play();
						if (on_ground) {
							Instantiate(bullet, gunground.position,gunground.rotation);
						}
						if (in_air) {
							Instantiate(bullet, gunjump.position,gunjump.rotation);
						}
					}
				}
			}
		}

	}
	void AnimationController()
	{
		//播放动画设置
		if (!hurtAction) {
			if (on_climbState) {
				if (Input.GetKey("j")) {
					anim.Play("MC_ShootLadder");
				}
				else {
					if (Input.GetKey("w")||Input.GetKey("s")) {
						anim.Play("MC_Climb");
					}
					else {
						anim.Play("MC_Idle_Ladder");
					}
				}
			}
			if (!on_climbState) {
				if (Input.GetKey("j")) {
					if (in_air) {
						anim.Play("MC_Shoot_Jump");
					}
					else {
						if (Input.GetKey("a")||Input.GetKey("d")) {
							anim.Play("MC_Shoot_Run");
						}
						else {
							anim.Play("MC_ShootStand");
						}
					}
				}
				else {
					if (in_air) {
							anim.Play("MC_Jump");
					}
					else {
						if (Input.GetKey("a")||Input.GetKey("d")) {
							anim.Play("MC_Run");
						}
						else {
							anim.Play("MC_Idle");
						}
					}
				}
			}
		}
		else {
			anim.Play("MC_Hurt");
		}

	}
	void AudioController()
	{
		if (!immune) {
			if (Input.GetKey("j")) {
				if (Time.time>shootTimer2&&shootUpLimit==false) {
					shootTimer2 =Time.time+shootInterval;
					GetComponent<AudioSource>().clip = audioshoot;
					GetComponent<AudioSource>().Play();
				}
			}
			else {
				if (in_air) {
					GetComponent<AudioSource>().clip = audiojump;
					GetComponent<AudioSource>().Play();
				}
			}
			if (hurtTrigger) {
				GetComponent<AudioSource>().clip = audiohurt;
				GetComponent<AudioSource>().Play();
			}
		}
	}
}
