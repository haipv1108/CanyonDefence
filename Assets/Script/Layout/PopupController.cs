using UnityEngine;
using System.Collections;

public class PopupController : MonoBehaviour {

	public void ClickClose() {
		gameObject.GetComponent<Animator> ().SetTrigger ("Close");
	}

	public void CloseAnim() {
		transform.parent.gameObject.SetActive (false);
	}


}
