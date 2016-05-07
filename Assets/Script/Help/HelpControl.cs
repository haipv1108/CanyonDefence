using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class HelpControl : MonoBehaviour {

	public string[] helpList = {
		"Hãy ấn vào các ô vuông để đặt quân",
		"Nếu các ô vuông đó có quân rồi màn hình upgrade sẽ hiện lên",
		"Hay cho tôi thấy cánh tay của các bạn"
	};

	public int currentHelp;

	public Text textHelp;

	public Button back, next, skip;

	public GameObject confirmPopup;

	void Start() {
		currentHelp = 0;
		SetHelp ();
	}


	private void SetHelp() {
		textHelp.text = helpList [currentHelp];



		if (currentHelp == 0) {
			DisableButton (back);
		} else {
			EnableButton (back);
		}

		if (currentHelp == helpList.Length - 1) {
			DisableButton (next);
		} else {
			EnableButton (next);
		}
	}

	void DisableButton(Button button) {
		button.image.color = new Color(1f,1f,1f,0.3f);
	}

	void EnableButton(Button button) {
		button.image.color = new Color(1f,1f,1f,1f);
	}

	public void BackHelp() {
		if (currentHelp == 0) {
			return;
		}
		--currentHelp;
		SetHelp ();
	}

	public void SkipHelp() {
		gameObject.SetActive (false);
		confirmPopup.SetActive (true);
	}

	public void NextHelp() {
		if (currentHelp == helpList.Length - 1) {
			return;
		}

		++currentHelp;
		SetHelp ();
	}
}
