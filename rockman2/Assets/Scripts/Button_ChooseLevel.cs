using UnityEngine;
using System.Collections;

public class Button_ChooseLevel : MonoBehaviour {

	UIController_S2 uiController_S2;
	public int levelNumber;
	public bool levelChoose;
	
	void Awake()
	{
		levelChoose = false;
		uiController_S2 = GameObject.Find ("UIController").GetComponent<UIController_S2>();
	}
	
	void Update()
	{
		if (Input.GetKey("j")) {
			uiController_S2.levelChoose =true;
			uiController_S2.levelNumber = levelNumber;
		}
	}
	void OnClick()
	{
		uiController_S2.levelChoose =true;
		uiController_S2.levelNumber = levelNumber;
	}
}
