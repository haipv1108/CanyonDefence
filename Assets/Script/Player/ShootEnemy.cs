using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEnemy : MonoBehaviour {

    public List<GameObject> enemiesInRange;

    private float lastShotTime;
    private PlayerData playerData;
    public GameObject target;

	public float range;

    void Start() {
        lastShotTime = Time.time;
        playerData = gameObject.GetComponentInChildren<PlayerData>();
    }

    void Update() {
        //GameObject target = null;

        //TODO: set target object cho bullet o day.
        float minimalEnemyDistance = float.MaxValue;
        //foreach (GameObject enemy in enemiesInRange) { }

        if (target != null) {
            if (Time.time - lastShotTime > playerData.CurrentLevel.fireRate) {
                Shoot(target.GetComponent<Collider2D>());
                lastShotTime = Time.time;
            }
            //Xoay player
            Vector3 direction = gameObject.transform.position - target.transform.position;
            gameObject.transform.rotation = Quaternion.AngleAxis(
                Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
                new Vector3(0, 0, 1));
        }
    }

    void Shoot(Collider2D target) {
        GameObject bulletPrefab = playerData.CurrentLevel.bullet;

        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = target.transform.position;
        startPosition.z = bulletPrefab.transform.position.z;
        targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.position = startPosition;
        BulletController bulletControl = newBullet.GetComponent<BulletController>();
        bulletControl.target = target.gameObject;
        bulletControl.startPosition = startPosition;
        bulletControl.targetPosition = targetPosition;

        //Animator & audio shot
    }

    void OnEnemyDestroy(GameObject enemy)
    {
        enemiesInRange.Remove(enemy);

    }

	public  float Distance(Vector2 v) {
		return Vector2.Distance (transform.position, v);
	}

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Enemy"))
        {
            enemiesInRange.Add(other.gameObject);
            EnemyDestructionDelegate del =
                other.gameObject.GetComponent<EnemyDestructionDelegate>();
            del.enemyDelegate += OnEnemyDestroy;
        }
    }*/
}
