using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	void Update () {
		Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);
		
		if (hit.collider != null)
		{
			if (hit.collider.tag == "Player") {
				Debug.Log ("Display Range Player");
			}
				return;
		}

		if (Input.GetMouseButtonDown (0)) {
			if(PlacePlayer.isActivePopup){
				Debug.Log("An mia di");
				PlacePlayer.instance.CloseAllPopup();
			}
		}
	}
}
