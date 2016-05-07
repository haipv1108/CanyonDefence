using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EventController : MonoBehaviour {

	public GameObject showRangeObject = null;
	public GameObject go = null;

	void Update () {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING) {
			if (Input.GetMouseButtonDown (0)) {
				Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
				
				if (hit.collider != null)
				{
					Debug.Log (hit.collider.tag);
					if (hit.collider.tag == "OpenSpot") {
						go = hit.collider.transform.gameObject.GetComponent<PlacePlayer>().player;
						if (go == null) {
							return;
						}
						if (go == showRangeObject) {
							return;
						} 
						if (showRangeObject != null) {
							showRangeObject.GetComponent<ShootEnemy>().HideRange();
						}
						Debug.Log ("Show hang");
						showRangeObject = go;
						showRangeObject.GetComponent<ShootEnemy>().ShowRange();
						return;
					}
					
				}else{
					if(PlacePlayer.isActivePopup){
						PlacePlayer.instance.CloseAllPopup();
					}
				}
				Debug.Log ("Tat hang");
				if (showRangeObject != null) {
					showRangeObject.transform.FindChild("RangeImage").gameObject.SetActive(false);
					showRangeObject = null;
				}
			}
		}

	}
}
