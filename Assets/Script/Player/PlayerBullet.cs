using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour {

    public float speed = 10;
    public int damage;
    public GameObject target;
    public Vector3 startPosition;
    public Vector3 targetPosition;

    private float distance;
    private float startTime;

    void Start() {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);

    }
}
