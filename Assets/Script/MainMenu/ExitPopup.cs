using UnityEngine;
using System.Collections;

public class ExitPopup : MonoBehaviour {

    public void Open() {
        if(!gameObject.activeSelf)
            gameObject.SetActive(true);
		if(SoundManager.instance != null){
			SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
		}
    }

    public void Close() {
		//Cho lai gamestate 
		if (GameManager.instance != null) {
			if (GameManager.instance.preGameState == GAMESTATE.GAMESTART) {
				GameManager.instance.SetGameState (GAMESTATE.GAMESTART);
			} else {
				GameManager.instance.SetGameState (GAMESTATE.GAMEPLAYING);
			}
		}
        gameObject.SetActive(false);
    }

    public void QuitGamePlay() {
		GameManager.instance.SetGameState (GAMESTATE.MENU);
        gameObject.SetActive(false);
		LoadScene.Load (Strings.SCEN_MENU);
    }

	public void RetryGamePlay(){
		LoadScene.Load (Application.loadedLevelName);
	}

    public void QuitGame()
    {
        Application.Quit();
    }
}
