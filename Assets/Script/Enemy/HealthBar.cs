using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

    public float maxHealth = 100;
    public float currentHealth = 100;
    private float originalScale;

    void Start() {
        originalScale = gameObject.transform.localScale.x;
    }

    void Update() {
        Vector3 tmpScale = gameObject.transform.localScale;
        tmpScale.x = currentHealth / maxHealth * originalScale;
        gameObject.transform.localScale = tmpScale;
    }

	public void Damage(float damage){
		if (currentHealth == 0)
			return;
		currentHealth -= damage;
		if (currentHealth < 0)
			currentHealth = 0;
		Vector3 localScale = transform.localScale;

		localScale.x = currentHealth / maxHealth * 100/65*100;
		transform.localScale = localScale;
	}
}
