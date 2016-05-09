using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour {

	public static SpawnEnemy instance;
	public Wave[] waves;
	public int timeBetweenWaves = 5;

	private float lastSpawnTime;

	private int enemiesSpawned = 0;

	private GameManager gameManager;

	public GameObject[] waypoints;

	public GameObject testEnemyPrefab;

	public NextWaveLabel nextWaveLabel;

	public NextWaveLabel nextWaveFlyLabel;

	private bool isOpenningFlyLabel = false;
	
	void Awake(){
		instance = this;
	}

	void Start(){
		lastSpawnTime = Time.time;
		gameManager = GameManager.instance;
	}

	void  Update() {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING) {
			int currentWave = gameManager.Wave;
			if (currentWave < waves.Length) {
				float timeInterval = Time.time - lastSpawnTime;
				float spawnInterval = waves[currentWave].spawnInterval;
				if (enemiesSpawned == 0 && isOpenningFlyLabel == false) {
					GameObject newEnemy = (GameObject)
						Instantiate(waves[currentWave].enemyPrefab);
					if (newEnemy.GetComponent<Enemy>().type == Type.FLY) {
						Debug.Log ("Fly wave");
						nextWaveFlyLabel.Open();//Fly wave
						isOpenningFlyLabel = true;
					}
					Destroy(newEnemy);
				}
				if (((enemiesSpawned == 0 && timeInterval > timeBetweenWaves) ||
				     timeInterval > spawnInterval) && 
				    enemiesSpawned < waves[currentWave].maxEnemies) {
					// neu chua ra con enemy nao && thoi gian troi qua > thoi gian giua moi waves
					// hoac thoi gian troi qua > thoi gian giua moi wave && chua ra het enemy
					if (isOpenningFlyLabel == true)
						isOpenningFlyLabel = false;
					lastSpawnTime = Time.time;
					GameObject newEnemy = (GameObject)
						Instantiate(waves[currentWave].enemyPrefab);
					newEnemy.GetComponent<Enemy>().waypoints = waypoints;
					newEnemy.GetComponent<Enemy>().SetEnemyState(EnemyState.START_RUN);
					enemiesSpawned++;
				}


				// 4 
				if (enemiesSpawned == waves[currentWave].maxEnemies &&
				    GameObject.FindGameObjectWithTag("Enemy") == null) {
					if (gameManager.Wave + 1 < waves.Length)
						gameManager.Wave++; 
					else {
						gameManager.gameOver = true;
						//GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
						//gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
						Debug.Log ("You win");
						GameManager.instance.SetGameState(GAMESTATE.WINGAME);
						return;

					}
					int currentWay = gameManager.Wave;
					//NEXT WAVE
					if (currentWay < waves.Length) {
						nextWaveLabel.Open();
						enemiesSpawned = 0;
						lastSpawnTime = Time.time;

					}
					//gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
				}
				// 5 
			} else {
				gameManager.gameOver = true;
				//GameObject gameOverText = GameObject.FindGameObjectWithTag ("GameWon");
				//gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
				Debug.Log ("You win");
				GameManager.instance.SetGameState(GAMESTATE.WINGAME);
			}
		}
	}

	public int getCurrentWave(){
		return gameManager.Wave;
	}

	public int getMaxWave(){
		return waves.Length;
	}
}
