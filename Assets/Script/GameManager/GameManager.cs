using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
	public ShakeCamera shakeCamera;
	public GAMESTATE gamestate;
	public GAMESTATE preGameState;

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

	private float timescale = 1.0f;
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
		timescale = 1.0f;
		SetGameState (GAMESTATE.GAMESTART);
	}

    void Start() {
        Gold = 1000;
		lives = 10;	
		if (SoundManager.instance != null) {
			SoundManager.instance.PlayBGM(BGM.GAMEPLAY);
		}
    }

	public void DecreeHealth() {
		if (lives > 0) {
			--lives;
			livesText.text = lives + "";
			//Am thanh khi mat mang
			if(SoundManager.instance != null){
				SoundManager.instance.PlaySFX(SFX.PLAYER_DIE);
			}
			//Rung man hinh
			shakeCamera.DoShake();
			//Rung dien thoai
			if (Attributes.isVibrationOn ()) {
				Handheld.Vibrate();
			}
			if (lives == 0) {
				Debug.Log ("Game Over: Lose");
				SetGameState(GAMESTATE.GAMEOVER);
			}
		}

	}

	public void SetGameState(GAMESTATE state){
		preGameState = gamestate;
		gamestate = state;
		switch (gamestate) {
			case GAMESTATE.GAMEPLAYING:
				Time.timeScale = timescale;
				break;
			case GAMESTATE.GAMEPAUSE:
				Time.timeScale = 0.0f;
				break;
			case GAMESTATE.GAMESTART:
				Time.timeScale = timescale;
				break;
			case GAMESTATE.GAMEOVER:
				timescale = 1.0f;
				Time.timeScale = timescale;
				break;
		}
	}

	void Update(){
		if (Input.GetKeyDown(KeyCode.T)) {
			Gold -= 100;
			Debug.Log("GOLD: " + Gold);
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			SetGameState(GAMESTATE.GAMEPLAYING);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			SetGameState(GAMESTATE.GAMEPAUSE);
		}
	}

	private void SetTimeScale(float time){
		timescale = time;
		Time.timeScale = timescale;
	}
}

public enum GAMESTATE{
	GAMEPLAYING,
	GAMEPAUSE,
	GAMESTART,
	GAMEOVER
}
