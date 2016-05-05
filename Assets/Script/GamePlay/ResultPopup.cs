using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResultPopup : MonoBehaviour {

	public Text defficulty;
	public Text waves;
	public Text score;

	public void Open(){
		LoadInfo ();
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}

	public void Retry(){
		//TODO Load application
		Application.LoadLevel (Application.loadedLevelName);
	}

	public void GoHome(){
		//TODO Set gamestate = menu
		//TODO Goto home menu
	}

	private void LoadInfo(){
		defficulty.text = LoadDefficulty ();
		waves.text = "Waves: 5/10";
		score.text = "Score: 30000";
	}

	private string LoadDefficulty(){
		string text = "";
		switch (Attributes.difficulty) {
			case 1:
				text = "Difficulty :  Easy";
				break;
			case 2: 
				text = "Difficulty :  Normal";
				break;
			case 3:
				text = "Difficulty :  Hard";
				break;
			default:
				text = "Difficulty :  Easy";
				break;
		}
		return text;
	}
}
