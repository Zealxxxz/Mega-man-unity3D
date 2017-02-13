using UnityEngine;
using System.Collections;

public class HPitems : MonoBehaviour {

	public int AddValue;
	int HpValue;
	int HpResult;
	public GameObject Player;
	GameObject sfxController;

	void Awake()
	{
		sfxController = GameObject.Find ("SFXController");
	}

	void OnTriggerEnter(Collider other)
	{

		if (other.tag=="Player") {
			sfxController.GetComponent<SFXcontroller>().SoundAddHP();
			HpResult =HpValue+AddValue;
			if (HpResult>28) {
				Player.GetComponent<PlayerControllerNew> ().HP=28;
			}
			else {
				Player.GetComponent<PlayerControllerNew> ().HP =HpResult;
			}
			Invoke("Des",0.1f);
		}
	}

	void FixedUpdate()
	{
		HpValue = Player.GetComponent<PlayerControllerNew> ().HP;

	}
	void Des()
	{
		Destroy (gameObject);
	}
}
