using UnityEngine;
using System.Collections;

public class HelpController : MonoBehaviour {

	public void ClickClose() {
		gameObject.GetComponent<Animator> ().SetTrigger ("Close");
	}

	public void CloseAnim() {
		transform.parent.gameObject.SetActive (false);
	}
}
