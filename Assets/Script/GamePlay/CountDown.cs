using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	
	public Text text;
	public Text[] texts;
	int count = 0;
	
	public void Count()
	{
		/*if (count == 1)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT03_START);
		if(count == 2)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT02_START);
		if(count == 3)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.COUNT01_START);
		if(count == 4)
			if(SoundManager.instance != null) SoundManager.instance.PlaySTART_OVER (STARTOVER.START);*/
		if (GameManager.instance.gamestate == GAMESTATE.GAMESTART) {
			if (count >= texts.Length)
			{
				GameManager.instance.SetGameState(GAMESTATE.GAMEPLAYING);
				Destroy(gameObject);
				return;
			}
			text.text = texts[count].text;
			count++;
		}

		
	}
}
