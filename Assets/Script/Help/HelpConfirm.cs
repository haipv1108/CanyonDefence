using UnityEngine;
using System.Collections;

public class HelpConfirm : MonoBehaviour {

	// Use this for initialization
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HelpNextTime() {
		gameObject.SetActive (false);
		Debug.Log ("lan sau lan con");
	}

	public void DisableHelpNextTime() {
		gameObject.SetActive (false);
		Debug.Log ("Lan sau ko con nua");
	}
}
