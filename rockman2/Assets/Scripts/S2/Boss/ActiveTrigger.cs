using UnityEngine;
using System.Collections;

public class ActiveTrigger : MonoBehaviour {

	public GameObject Boss;
	GameObject gameController;

	void Awake()
	{
		gameController = GameObject.Find ("GameController");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag=="Player") {
			Boss.GetComponent<BossFunctionNew>().ActiveSwitch =true;
			gameController.GetComponent<GameConrtoller_S2>().isInBossRomm =true;
			Invoke ("Move", 1f);
		}
	}
	void Move()
	{transform.position = new Vector3 (-1.4f, -1f, 0f);}
}
