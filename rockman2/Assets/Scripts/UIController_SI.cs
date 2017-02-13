using UnityEngine;
using System.Collections;

public class UIController_SI : MonoBehaviour {

	[HideInInspector]
	public bool gotoLevelSelectMenu;
	public GameObject menu_Flash;

	void Awake()
	{
		gotoLevelSelectMenu = false;
	}
	void Start()
	{
		Instantiate (menu_Flash, transform.position, transform.rotation);
	}

	void Update()
	{
		LoadLevelMenu ();
	}

	void LoadLevelMenu()
	{
		if (gotoLevelSelectMenu) {
			gotoLevelSelectMenu = false;
			Application.LoadLevel(1);
		}
	}
}
