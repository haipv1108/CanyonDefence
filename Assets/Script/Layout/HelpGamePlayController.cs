using UnityEngine;
using System.Collections;

public class HelpGamePlayController : MonoBehaviour {

	public GameObject[] HelpList;
	private int currentID;

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
			ClickBackBtn ();

		if (currentID + 1 <= HelpList.Length - 1 ) {
			SetStatus(currentID, false);
			currentID ++;
			SetStatus(currentID, true);
		}
	}

	public void ClickBackBtn()
	{
		if (currentID - 1 >= 0) {
			SetStatus(currentID, false);
			currentID --;
			SetStatus(currentID, true);
		}
	}

	public void ClickSkipBtn()
	{
		print ("Start Game................");
	}
}
