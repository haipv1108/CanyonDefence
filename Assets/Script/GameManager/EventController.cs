using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventController : MonoBehaviour {

	public GameObject showRangeObject = null;
	public GameObject go = null;

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
			
			if (hit.collider != null)
			{
				Debug.Log (hit.collider.tag);
				if (hit.collider.tag == "OpenSpot") {
					go = hit.collider.transform.gameObject.GetComponent<PlacePlayer>().player;
					if (go == showRangeObject) {
						return;
					} 
					if (showRangeObject != null) {
						showRangeObject.transform.FindChild("RangeImage").gameObject.SetActive(false);
					}
					Debug.Log ("Show hang");
					showRangeObject = go;
					showRangeObject.transform.FindChild("RangeImage").gameObject.SetActive(true);
					return;
				}
			}
			Debug.Log ("Tat hang");
			if (showRangeObject != null) {
				showRangeObject.transform.FindChild("RangeImage").gameObject.SetActive(false);
				showRangeObject = null;
			}
		}

		if (Input.GetMouseButtonDown (0)) {
			if(PlacePlayer.isActivePopup){
				Debug.Log("An mia di");
				PlacePlayer.instance.CloseAllPopup();
			}
		}
	}
}
