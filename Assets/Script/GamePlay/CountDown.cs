using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {
	
	public Text text;
	public Text[] texts;
	int count = 0;
	
	public void Count()
	{
		if (count == 1)
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.THREE);
		if (count == 2)
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.TWO);
		if (count == 3)
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.ONE);
		if (count == 4)
		if (SoundManager.instance != null)
			SoundManager.instance.PlaySFX (SFX.START);

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
