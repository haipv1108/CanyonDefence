using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

    public GameObject pauseObject;
    public GameObject x1Object;
    public GameObject soundObject;
    public Popup notifyPopupObject;

    public void Pause() {
        //notifyPopupObject.Open();
        //Change sprite
        pauseObject.transform.GetChild(0).gameObject.SetActive(true);
    }
}
