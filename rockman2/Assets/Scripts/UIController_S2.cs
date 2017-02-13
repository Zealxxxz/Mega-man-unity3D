using UnityEngine;
using System.Collections;

public class UIController_S2 : MonoBehaviour {

	[HideInInspector]
	public int levelNumber;
	public bool levelChoose;
	public GameObject menu_LevelSelect;
	
	void Awake()
	{
		levelChoose = false;
	}
	void Start()
	{
		Instantiate (menu_LevelSelect, transform.position, transform.rotation);
	}
	
	void Update()
	{
		gameStart ();
	}
	
	void gameStart()
	{
		if (levelChoose) {
			levelChoose = false;
			Application.LoadLevel(levelNumber+1);
			print(levelNumber+1);
		}
	}
}
