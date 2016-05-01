using UnityEngine;
using System.Collections;

public class MainMenuController : MonoBehaviour {

    public GameObject BgIn;
    public GameObject HelpCanvas;
    public GameObject ScoreCanvas;
    public GameObject SettingCanvas;

    // Use this for initialization
    void Start() {
        BgIn.SetActive(true);
        HelpCanvas.SetActive(false);
        ScoreCanvas.SetActive(false);
        SettingCanvas.SetActive(false);
		//Sound
		if (SoundManager.instance != null) {
			SoundManager.instance.PlayBGM(BGM.MENU);
		}
    }

    // Click Button
    public void PlayBtn() {
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}
        Application.LoadLevel(Strings.SCEN_SELECTMAP);
    }

    public void HelpBtn() {
        //		print ("Click Help Btn");
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
		}
        HelpCanvas.SetActive(true);
    }

    public void ScoreBtn() {
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
		}
        ScoreCanvas.SetActive(true);
    }

    public void SettingBtn() {
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.OPEN_DIALOG);
		}
        SettingCanvas.SetActive(true);
    }
}
