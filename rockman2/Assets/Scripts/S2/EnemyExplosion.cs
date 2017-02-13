using UnityEngine;
using System.Collections;

public class EnemyExplosion : MonoBehaviour {



	void FixedUpdate () {
		GetComponent<Animator>().Play("explosion");
	}
}
