using UnityEngine;
using System.Collections;

public class TestAudioListener : MonoBehaviour {

	public AudioListener listener;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (listener.isActiveAndEnabled) {
			Debug.Log("Nhu cc");
		}
	}
}
