using UnityEngine;
using System.Collections;

public class HelpGamePlayController : MonoBehaviour {

	public GameObject[] HelpList;
	private int currentID;

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		//TODO Change gamestate
		gameObject.SetActive (false);
		// Luu lai thong so
		Attributes.SetWatchHelp ();//Luu lai trang thai nguoi dung xem rooi
		if (GameManager.instance != null) {
			if(GameManager.instance.preGameState == null){
				GameManager.instance.SetGameState(GAMESTATE.GAMESTART);
			}else{
				GameManager.instance.SetGameState(GameManager.instance.preGameState);
			}

		}
	}

	// Use this for initialization
	void Start () {
		currentID = 0;
		HelpList [0].SetActive (true);
	}

	void SetStatus(int index, bool value)
	{
		HelpList [index].SetActive (value);
	}

	public void ClickNextBtn()
	{
		if (currentID + 1 >= HelpList.Length)
			ClickSkipBtn ();

		if (currentID + 1 <= HelpList.Length - 1) {
			SetStatus (currentID, false);
			currentID ++;
			SetStatus (currentID, true);
		}

		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}
	}

	public void ClickBackBtn()
	{
		if (currentID - 1 >= 0) {
			SetStatus(currentID, false);
			currentID --;
			SetStatus(currentID, true);
		}
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}
	}

	public void ClickSkipBtn()
	{
		print ("Start Game................");
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}
		Close ();
	}
}
