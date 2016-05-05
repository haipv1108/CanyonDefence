using UnityEngine;
using System.Collections;

public class ExitPopup : MonoBehaviour {

    public void Open() {
        if(!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

    public void Close() {
		//Cho lai gamestate 
		if (GameManager.instance.preGameState == GAMESTATE.GAMESTART) {
			GameManager.instance.SetGameState (GAMESTATE.GAMESTART);
		} else {
			GameManager.instance.SetGameState (GAMESTATE.GAMEPLAYING);
		}
        gameObject.SetActive(false);
    }

    public void QuitGamePlay() {
        gameObject.SetActive(false);
        Application.LoadLevel(Strings.SCEN_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
