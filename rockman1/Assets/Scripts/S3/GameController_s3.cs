using UnityEngine;
using System.Collections;

public class GameController_s3 : MonoBehaviour {

	public MovieTexture movTexture;

	void Start()
	{
		movTexture.loop = false;
		GetComponent<Renderer>().material.mainTexture = movTexture;
		movTexture.Play();
	}
	void OnGUI()
	{
		//GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), movTexture, ScaleMode.StretchToFill);
	}
}
