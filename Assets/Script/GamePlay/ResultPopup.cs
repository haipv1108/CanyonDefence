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
		waves.text = LoadWavesInfo ();
		score.text = LoadScoreInfo ();
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

	private string LoadWavesInfo(){
		string text = "Waves: ";
		if (SpawnEnemy.instance != null) {
			int maxWave = SpawnEnemy.instance.getMaxWave ();
			int currentWave = SpawnEnemy.instance.getCurrentWave ();
			text += currentWave + "/" + maxWave;
		}
		return text;
	}

	private string LoadScoreInfo(){
		string text = "Scores: ";
		if (GameManager.instance != null) {
			text += GameManager.instance.Score;
		}
		return text;
	}
}
