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
    }

    // Click Button
    public void PlayBtn() {
        Application.LoadLevel(Strings.SCEN_SELECTMAP);
    }

    public void HelpBtn() {
        //		print ("Click Help Btn");
        HelpCanvas.SetActive(true);
    }

    public void ScoreBtn() {
        ScoreCanvas.SetActive(true);
    }

    public void SettingBtn() {
        SettingCanvas.SetActive(true);
    }
}
