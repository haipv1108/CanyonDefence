using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

	ShootEnemy shootEnemy;
	private float radius = 0.0f;

	public Type type;
	// Use this for initialization
	void Start () {
		radius = gameObject.GetComponent<CircleCollider2D> ().radius;
		shootEnemy = transform.parent.GetComponent<ShootEnemy>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			Enemy enemy = other.gameObject.GetComponent<Enemy>();
			if (enemy.type != this.type)
				return;
			shootEnemy.AddEnemyInRange(other.gameObject);
			enemy.observers.Add(shootEnemy);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			shootEnemy.DeleteEnemyInRange(other.gameObject);

		}
	}
	

	//An soi, moi lan se upgrade len 1.3
	public float SetRadius(){
		radius = radius * 1.5f;
		gameObject.GetComponent<CircleCollider2D> ().radius = radius;
		return radius;
	}
}
