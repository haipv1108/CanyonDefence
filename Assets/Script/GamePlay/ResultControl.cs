using UnityEngine;
using System.Collections;

public class ResultControl : MonoBehaviour {

	public ResultPopup winPopup;
	public ResultPopup losePopup;

	public void YouWin(){
		//Am thanh
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.VICTORY);
		}
		winPopup.Open ();
		losePopup.Close ();
	}

	public void YouLose(){
		//Am thanh
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.LOSE_GAME);
		}
		losePopup.Open ();
		winPopup.Close ();
	}
}
