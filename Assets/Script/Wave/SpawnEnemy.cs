using UnityEngine;
using System.Collections;

public class SpawnEnemy : MonoBehaviour {

	public Wave[] waves;
	public int timeBetweenWaves = 5;

	private float lastSpawnTime;

	private int enemiesSpawned = 0;

	private GameManager gameManager;

	void Start(){
		lastSpawnTime = Time.time;
		gameManager = GameManager.instance;
	}

	void  Update() {
		/*
		int currentWave = gameManager.Wave;
		if (currentWave < waves.Length) {
			// 2
			float timeInterval = Time.time - lastSpawnTime;
			float spawnInterval = waves[currentWave].spawnInterval;
			if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
			     timeInterval > spawnInterval) && 
			    enemiesSpawned < waves[currentWave].maxEnemies) {
				// neu chua ra con enemy nao && thoi gian troi qua > thoi gian giua moi waves
				// hoac thoi gian troi qua > thoi gian giua moi wave && chua ra het enemy
				lastSpawnTime = Time.time;
				GameObject newEnemy = (GameObject)
					Instantiate(waves[currentWave].enemyPrefab);
				newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
				enemiesSpawned++;
			}
			// 4 
			if (enemiesSpawned == waves[currentWave].maxEnemies &&
			    GameObject.FindGameObjectWithTag("Enemy") == null) {
				gameManager.Wave++;
				gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
				enemiesSpawned = 0;
				lastSpawnTime = Time.time;
			}
			// 5 
		} else {
			gameManager.gameOver = true;
			//GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
			//gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
		}
		*/
	}
}
