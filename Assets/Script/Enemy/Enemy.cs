using UnityEngine;
using System.Collections;

enum MoveDirection {
	TOP_LEFT,
	TOP_RIGHT,
	BOTTOM_LEFT,
	BOTTOM_RIGHT
}

public class Enemy : MonoBehaviour {

	public  float speed;

	public bool isMoving ;

	Vector3 direction, destination;

	MoveDirection moveDirection;
	
	// Use this for initialization
	void Start () {
		direction = new Vector3 (1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if (MoveComplete()) {
				isMoving = false;
				return;
			}
			ContinueMove();
		}
	}

	bool MoveComplete() {
		MoveDirection moveDirection = CalculateMoveDirection ();

		switch (this.moveDirection) {
		case MoveDirection.BOTTOM_LEFT:
			if (moveDirection == MoveDirection.TOP_RIGHT)
				return true;
			return false;
		case MoveDirection.BOTTOM_RIGHT:
			if (moveDirection == MoveDirection.TOP_LEFT)
				return true;
			return false;
		case MoveDirection.TOP_LEFT:
			if (moveDirection == MoveDirection.BOTTOM_RIGHT)
				return true;
			return false;
		case MoveDirection.TOP_RIGHT:
			if (moveDirection == MoveDirection.BOTTOM_LEFT)
				return true;
			return false;
		}
		return false;
	}

	void ContinueMove() {
		Vector3 currentPostion = transform.position;
		Vector3 distanceNextMove = direction;

		distanceNextMove.x *= speed;
		distanceNextMove.y *= speed;
		currentPostion += distanceNextMove;
		transform.position = currentPostion;
	}

	public void Move(Vector3 destination) {
		if (isMoving)
			return;
		this.destination = destination;
		isMoving = true;
		Vector3 preDirection = direction;
		direction = (destination - transform.position).normalized;
		direction.z = 0;
		Debug.Log ("Vector direction:" + direction);
		moveDirection = CalculateMoveDirection ();

		CalculateRotation (preDirection);
	}

	void CalculateRotation(Vector3 preDirection) {
		Vector3 rotation = transform.localRotation.eulerAngles;
		Debug.Log ("Angle: " + Vector2.Angle(preDirection,direction));
		Vector3 cross = Vector3.Cross(preDirection, direction);
		
		//rotation.z += Vector2.Angle(preDirection,direction);
		if (cross.z > 0) {
			rotation.z += Vector2.Angle(preDirection,direction);
		} else {
			rotation.z -= Vector2.Angle(preDirection,direction);
		}
		transform.GetChild (0).transform.Rotate (rotation);
	}

	MoveDirection CalculateMoveDirection() {
		MoveDirection moveDirection;

		Vector3 currentPosition = transform.position;
		if (currentPosition.x <= destination.x && currentPosition.y <= destination.y) {
			moveDirection = MoveDirection.BOTTOM_LEFT;
		}
		else if (currentPosition.x <= destination.x && currentPosition.y >= destination.y) {
			moveDirection = MoveDirection.TOP_LEFT;
		}
		else if (currentPosition.x >= destination.x && currentPosition.y <= destination.y) {
			moveDirection = MoveDirection.BOTTOM_RIGHT;
		} else 
			moveDirection = MoveDirection.TOP_RIGHT;

		return moveDirection;
	}
	
}
