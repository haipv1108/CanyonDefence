using UnityEngine;
using System.Collections;

public class DragControl : MonoBehaviour {

	private Vector3 screenPoint;
	private Vector3 offset;

	void Start(){
		Debug.Log ("Khoi dong");
	}

	void OnMouseDown(){
		Debug.Log ("Click vao");
		screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
		offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}
	
	void OnMouseDrag(){
		Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
		Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;
		transform.position = cursorPosition;
	}
}
