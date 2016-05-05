using UnityEngine;
using System.Collections;

public class SoundListener : MonoBehaviour {

	public SettingSound soundObject;

	void Start(){
		soundObject.Close ();
	}

	// Update is called once per frame
	void Update () {
		if (Application.platform == RuntimePlatform.Android) {
			if (Input.GetKey(KeyCode.Menu))
				soundObject.Open();
		}
	}
}
