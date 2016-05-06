using UnityEngine;
using System.Collections;

public class HUDController : MonoBehaviour {

	public GameObject settingPopup;
	public GameObject speedObject;
	public GameObject pauseObject;

	public void Setting(){
		//Set game state
		if (GameManager.instance != null) {
			GameManager.instance.SetGameState(GAMESTATE.SETTING);
		}
		settingPopup.SetActive (true);
	}

	public void CloseSetting(){
		//Xu ly game state
		if (GameManager.instance != null) {
			if(GameManager.instance.gamestate == GAMESTATE.SETTING){
				GameManager.instance.SetGameState(GAMESTATE.GAMEPLAYING);
			}
		}
		settingPopup.SetActive (false);
	}

	public void UpSpeedGame(){
		GameObject x1 = speedObject.transform.FindChild ("X1").gameObject;
		GameObject x2 = speedObject.transform.FindChild ("X2").gameObject;
		float time = 1.0f;
		if (x1.activeSelf) {
			//Set time scale
			x1.SetActive (false);
			x2.SetActive (true);
			time = 2.0f;
		} else {
			x1.SetActive(true);
			x2.SetActive(false);
			time = 1.0f;
		}
		if(GameManager.instance != null){
			GameManager.instance.SetTimeScale(time);
		}
	}
	
}
