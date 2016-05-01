using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;
	private Vector3 originPosition;
		

	float mfX, mfY;



    void Start() {
        originalScale = gameObject.transform.localScale.x;
		originPosition = transform.position;

		mfX = transform.position.x / transform.localScale.x;
    }

    void Update() {
		/*
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
		*/
    }

	public void Damage(float damage){
		Debug.Log ("Damage");
		if (currentHealth == 0)
			return;
		currentHealth -= damage;
		if (currentHealth <= 0) {
			currentHealth = 0;
			Enemy enemy = transform.parent.GetComponent<Enemy>();
			enemy.actionAfterDestroy += () => {

				Debug.Log ("Cong them vang");
			};
			enemy.SetEnemyState(EnemyState.DESTROY);
		}

		Vector3 localScale = transform.localScale;

		localScale.x = currentHealth / maxHealth * originalScale;
		transform.localScale = localScale;

	}
}
