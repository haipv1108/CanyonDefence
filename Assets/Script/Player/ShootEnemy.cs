using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootEnemy : MonoBehaviour {

    public List<GameObject> enemiesInRange;

    private float lastShotTime;
    private PlayerData playerData;

    void Start() {
        lastShotTime = Time.time;
        playerData = gameObject.GetComponentInChildren<PlayerData>();
    }

    void Update() {
        GameObject target = null;

        float minimalEnemyDistance = float.MaxValue;
        foreach (GameObject enemy in enemiesInRange) { }
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
}
