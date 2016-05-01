using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

    public Text goldText;
    public int gold;
    public int Gold {
        get { return gold; }
        set {
            gold = value;
            goldText.text = gold.ToString();
        }
    }

    public Text waveText;

	public Text livesText;

	public int lives;

    public GameObject[] nextWaveLabels;

    public bool gameOver = false;

    private int wave;
    public int Wave {
        get { return wave; }
        set {
            wave = value;
            if (!gameOver) {
                for (int i = 0; i < nextWaveLabels.Length; i++) {
                    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                }
            }
//            waveText.text = (wave + 1).ToString();
        }
    }

    void Awake(){
		instance = this;
	}

    void Start() {
        Gold = 1000;
		lives = 10;	
    }

	public void DecreeHealth() {
		if (lives > 0) {
			--lives;
			livesText.text = lives + "";
			if (lives == 0) {
				Debug.Log ("Game Over: Lose");
			}
		}


	}
}
