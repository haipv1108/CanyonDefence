using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    public GameObject selectDifficulty;
    public SelectController selectController;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (selectDifficulty.activeSelf)
            {
                selectController.BackSelectMap();
                Debug.Log("select map : true");
            }
            else {
                //Back to menu scene
                selectController.BackMainMenu();
                Debug.Log("select map: false");
            }
        }
    }
}
