using UnityEngine;
using System.Collections;

public class GameStart_Button : MonoBehaviour {

	UIController_SI uiController_SI;

	void Awake()
	{
		uiController_SI = GameObject.Find ("UIController").GetComponent<UIController_SI>();
	}

	void Update()
	{
		if (Input.GetKey("j")) {
			uiController_SI.gotoLevelSelectMenu =true;
		}
	}
	void OnClick()
	{
		uiController_SI.gotoLevelSelectMenu =true;
	}
}
