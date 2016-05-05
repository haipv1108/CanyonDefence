using UnityEngine;
using System.Collections;

public class ResultControl : MonoBehaviour {

	public ResultPopup winPopup;
	public ResultPopup losePopup;

	public void YouWin(){
		winPopup.Open ();
		losePopup.Close ();
	}

	public void YouLose(){
		losePopup.Open ();
		winPopup.Close ();
	}
}
