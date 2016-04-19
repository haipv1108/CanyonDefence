using UnityEngine;
using System.Collections;

public class ExitPopup : MonoBehaviour {

    public void Open() {
        if(!gameObject.activeSelf)
            gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
    }

    public void QuitGamePlay() {
        gameObject.SetActive(false);
        Application.LoadLevel(Strings.SCEN_MENU);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
