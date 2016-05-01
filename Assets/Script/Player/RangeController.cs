using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

	ShootEnemy shootEnemy;
	// Use this for initialization
	void Start () {
		shootEnemy = transform.parent.GetComponent<ShootEnemy>();
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			shootEnemy.AddEnemyInRange(other.gameObject);
			other.gameObject.GetComponent<Enemy>().observers.Add(shootEnemy);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			shootEnemy.DeleteEnemyInRange(other.gameObject);

		}
	}

}
