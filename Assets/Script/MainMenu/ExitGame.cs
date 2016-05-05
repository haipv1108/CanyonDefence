using UnityEngine;

public class ExitGame : MonoBehaviour {

    public ExitPopup exitPopup;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
			// Cho game dung lai
			if(GameManager.instance != null){
				GameManager.instance.SetGameState(GAMESTATE.GAMEPAUSE);
			}
            exitPopup.Open();
        }
		if (GameManager.instance != null && GameManager.instance.gamestate == GAMESTATE.GAMEPAUSE) {
			// Cho game dung lai
			GameManager.instance.SetGameState(GAMESTATE.GAMEPAUSE);
			exitPopup.Open();
		}
    }

    
}
