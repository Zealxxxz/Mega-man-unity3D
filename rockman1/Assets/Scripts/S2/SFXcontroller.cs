using UnityEngine;
using System.Collections;

public class SFXcontroller : MonoBehaviour {

	public AudioClip attackEffective;
	public AudioClip attackFall;
	public AudioClip enemyShoot;
	public AudioClip addHP;

	public void SoundAttackEffective()
	{
		GetComponent<AudioSource>().clip =attackEffective;
		GetComponent<AudioSource>().Play();
	}
	public void SoundAttackFall()
	{
		GetComponent<AudioSource>().clip =attackFall;
		GetComponent<AudioSource>().Play();
	}
	public void SoundAttackShoot()
	{
		GetComponent<AudioSource>().clip =enemyShoot;
		GetComponent<AudioSource>().Play();
	}

	public void SoundAddHP()
	{
		GetComponent<AudioSource>().clip =addHP;
		GetComponent<AudioSource>().Play();
	}
}
