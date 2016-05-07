using UnityEngine;
using System.Collections;

public class NextWaveLabel : MonoBehaviour {

	public void Close(){
		if (GameManager.instance != null) {
			GameManager.instance.SetGameState(GAMESTATE.GAMEPLAYING);
		}
		gameObject.SetActive (false);
	}

	public void Open(){
		if (GameManager.instance != null) {
			GameManager.instance.SetGameState(GAMESTATE.NEXTWAVE);
		}
		gameObject.SetActive (true);
	}
}
