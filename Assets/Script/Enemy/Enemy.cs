using UnityEngine;
using System.Collections;

public enum MoveDirection {
	TOP_LEFT,
	TOP_RIGHT,
	BOTTOM_LEFT,
	BOTTOM_RIGHT,
	TOP,
	RIGHT,
	LEFT,
	BOTTOM
}

public enum EnemyState {
	START_RUN,
	DESTROY
}

public class Enemy : MonoBehaviour {

	public  float speed;

	public bool isMoving ;

	Vector3 direction, destination;

	MoveDirection moveDirection;

	public GameObject[] wayPoints;

	int currentWayPointDestination = -1;

	EnemyState enemyState;

	// Use this for initialization
	void Start () {

		MoveByWayPoints ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isMoving) {
			if (MoveComplete ()) {
				isMoving = false;
				if (currentWayPointDestination == wayPoints.Length-1) {
					currentWayPointDestination = -1;
					isMoving = false;
					Debug.Log ("All waypoint move  complete!");
					SetEnemyState(EnemyState.DESTROY);
					return;
				}
				
				Move(wayPoints[++currentWayPointDestination].transform.position);
				return;
			}
			
			ContinueMove ();
		}
	}

	public void SetEnemyState(EnemyState state) {
		if (enemyState == state)
			return;
		enemyState = state;
		switch (state) {
		case EnemyState.DESTROY:
			Debug.Log ("Destroy game object");
			Destroy(gameObject);
			break;
		case EnemyState.START_RUN:
			MoveByWayPoints();
			break;
		}
	}

	public void MoveByWayPoints() {
		if (wayPoints.Length <= 1) {
			Debug.Log ("Waypoints Empty");
			return;
		}

		transform.position = wayPoints [0].transform.position;
		currentWayPointDestination = 0;
		direction = new Vector3 (1, 0, 0);
		Move(wayPoints[++currentWayPointDestination].transform.position);
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
		case MoveDirection.TOP:
			if (moveDirection == MoveDirection.BOTTOM)
				return true;
			return false;
		case MoveDirection.BOTTOM:
			if (moveDirection == MoveDirection.TOP)
				return true;
			return false;
		case MoveDirection.LEFT:
			if (moveDirection == MoveDirection.RIGHT)
				return true;
			return false;
		case MoveDirection.RIGHT:
			if (moveDirection == MoveDirection.LEFT)
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
		Debug.Log ("Destination: " + destination);
		this.destination = destination;
		isMoving = true;
		Vector3 preDirection = direction;
		direction = (destination - transform.position).normalized;
		direction.z = 0;
		Debug.Log ("Vector direction:" + direction);
		moveDirection = CalculateMoveDirection ();
		Debug.Log ("MoveDirection: " + moveDirection);
		CalculateRotation (preDirection);
	}

	void CalculateRotation(Vector3 preDirection) {
		if (preDirection == direction && direction == Vector3.zero) {
			return;
		}
		Vector3 rotation = transform.localRotation.eulerAngles;
		Debug.Log ("pre: " + preDirection + "cur: " + direction);
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
		if (currentPosition.x < destination.x && currentPosition.y < destination.y) {
			moveDirection = MoveDirection.BOTTOM_LEFT;
		} else if (currentPosition.x < destination.x && currentPosition.y > destination.y) {
			moveDirection = MoveDirection.TOP_LEFT;
		} else if (currentPosition.x > destination.x && currentPosition.y < destination.y) {
			moveDirection = MoveDirection.BOTTOM_RIGHT;
		} else if (currentPosition.x > destination.x && currentPosition.y > destination.y) {
			moveDirection = MoveDirection.TOP_RIGHT;
			
		} else if (currentPosition.x == destination.x && currentPosition.y > destination.y) {
			moveDirection = MoveDirection.TOP;
		} else if (currentPosition.x == destination.x && currentPosition.y < destination.y) {
			moveDirection = MoveDirection.BOTTOM;
		} else if (currentPosition.x > destination.x && currentPosition.y == destination.y) {
			moveDirection = MoveDirection.RIGHT;
		} else {
			moveDirection = MoveDirection.LEFT;
		}

		return moveDirection;
	}
	
}
