using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

	public GameObject BgIn;
	public GameObject HelpCanvas;

	// Use this for initialization
	void Start () {
		BgIn.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Click Button
	public void PlayBtn() {
		Application.LoadLevel ("SelectMap");
	}

	public void HelpBtn() {
//		print ("Click Help Btn");
		HelpCanvas.SetActive (true);
	}

	public void ScoreBtn() {
		print ("Click Score Btn");
	}
}
