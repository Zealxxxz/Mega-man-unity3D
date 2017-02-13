using UnityEngine;
using System.Collections;

public class EnemyProperty : MonoBehaviour {

	public int HP;
	public int value;
	public GameObject explosion;
	bool isDeath;
	GameObject sfxController;

	public GameConrtoller_S2 gameController_S2;

	bool inHurtPosition;
	//系统启用敌人
	void Awake()
	{
		sfxController = GameObject.Find ("SFXController");
	}

	void FixedUpdate()
	{
		if (HP<=0) {
			Death();
		}
	}
	//敌人受伤
	public void TakeDamage()
	{
		HP = HP - 1;
	}
	//敌人死亡
	void Death()
	{
		isDeath = true;
		Destroy (gameObject);
		sfxController.GetComponent<SFXcontroller>().SoundAttackEffective();
		if (isDeath) {
			DeathAnim();
		}
		//敌人死亡，、、播放死亡动画
		//加分
		gameController_S2.AddScore (value);
	}
	void DeathAnim()
	{
		isDeath = false;
		Instantiate(explosion, transform.position, transform.rotation);
		Invoke ("Dispear", 0.3f);
	}

	void Dispear()
	{
		Destroy (explosion);
	}
}
