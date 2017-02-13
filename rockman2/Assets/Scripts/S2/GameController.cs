using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText restartText;
	private bool gameOver;
	//游戏开场，显示分数，切换场景，死亡后跳转,游戏结束动画
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="DeadZone") {
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
