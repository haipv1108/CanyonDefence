using UnityEngine;
using System.Collections;

public class RangeController : MonoBehaviour {

	ShootEnemy shootEnemy;
	// Use this for initialization
	void Start () {
		shootEnemy = transform.parent.GetComponent<ShootEnemy>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			shootEnemy.AddEnemyInRange(other.gameObject);
			other.GetComponent<Enemy>().actionAfterDestroy = () => {
				shootEnemy.DeleteEnemyInRange(other.gameObject);
				GameManager.instance.DecreeHealth();
			};
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.gameObject.tag.Equals("Enemy")) {
			shootEnemy.DeleteEnemyInRange(other.gameObject);

		}
	}

}
