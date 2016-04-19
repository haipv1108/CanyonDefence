using UnityEngine;

public class ExitGame : MonoBehaviour {

    public ExitPopup exitPopup;

	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            exitPopup.Open();
        }
    }

    
}
