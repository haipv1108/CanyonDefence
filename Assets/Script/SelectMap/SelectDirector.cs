using UnityEngine;
using System.Collections;

public class SelectDirector : MonoBehaviour {

	public GameObject nextObj;

	public void CloseCanvas() {
		gameObject.transform.parent.gameObject.SetActive (false);
		nextObj.SetActive (true);
	}
}
