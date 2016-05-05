using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ScorePopup : MonoBehaviour {

	public Text listScore;
	// Use this for initialization
	void Start () {
		listScore.text = "";
		LoadListScore ();
	}

	private void LoadListScore(){
		List<string> listStringScore = Attributes.getListDataScore ();
		foreach(string textScore in listStringScore){
			listScore.text += textScore + "\n";
		}
	}
}
