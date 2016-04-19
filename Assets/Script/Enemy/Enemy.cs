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
		direction = (destination - transform.position).normalized;
		direction.z = 0;
		Debug.Log ("Vector direction:" + direction);
		moveDirection = CalculateMoveDirection ();
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
		Debug.Log ("Move direction: " + moveDirection);

		return moveDirection;
	}
	
}
