using UnityEngine;
using System.Collections;

public class PauseGameButton : MonoBehaviour {

	private GameObject pauseOb;
	private GameObject continueOb;

	// Use this for initialization
	void Start () {
		pauseOb = gameObject.transform.FindChild ("PauseOb").gameObject;
		continueOb = gameObject.transform.FindChild ("Continue").gameObject;
		continueOb.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING && continueOb.activeSelf) {
			pauseOb.SetActive(true);
			continueOb.SetActive(false);
		}
	}

	public void PauseGame(){
		if (pauseOb.activeSelf) {
			//Pause game
			pauseOb.SetActive(false);
			continueOb.SetActive(true);
			//Set gamestate
			if (GameManager.instance != null) {
				GameManager.instance.SetGameState(GAMESTATE.GAMEPAUSE);
			}
		}

	}
}
