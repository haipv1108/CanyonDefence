using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {

	public Enemy enemy;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			if (Input.GetMouseButtonDown(0)) {
				Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				RaycastHit2D hit = Physics2D.Raycast(worldPoint,Vector2.zero);

				if (hit.collider != null) {
					if (hit.collider.tag == "Enemy") {
						Debug.Log ("KIMOCHI");
						hit.collider.gameObject.transform.GetChild(2).GetComponent<HealthBar>().Damage(5);
					}
				} else {
					Debug.Log ("WTF");
					enemy.Move(Camera.main.ScreenToWorldPoint(Input.mousePosition));
				}
			}
		}

	}
}
