using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectController : MonoBehaviour {

	public GameObject mapObj;
	public GameObject difObj;

	public GameObject map1;
	public GameObject map2;
	public GameObject map3;
	private Animator map1Anim;
	private Animator map2Anim;
	private Animator map3Anim;

	public GameObject dif1;
	public GameObject dif2;
	public GameObject dif3;
	private Animator dif1Anim;
	private Animator dif2Anim;
	private Animator dif3Anim;

	public Text textEasy;
	public Text textMedium;
	public Text textHard;

	// Use this for initialization
	void Start () {
		mapObj.SetActive (true);
		difObj.SetActive (false);

		map1Anim = map1.GetComponent<Animator> ();
		map2Anim = map2.GetComponent<Animator> ();
		map3Anim = map3.GetComponent<Animator> ();

		dif1Anim = dif1.GetComponent<Animator> ();
		dif2Anim = dif2.GetComponent<Animator> ();
		dif3Anim = dif3.GetComponent<Animator> ();

		//Sound
		if (SoundManager.instance != null) {
			SoundManager.instance.PlayBGM(BGM.SELECT_MAP);
		}
	}

	/* ------------ Click Button ------------*/
	// Chon Map
	public void SelectMap(int id) {
		//Sound
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}

		if (id >= 1 && id <= 3)
			Attributes.mapID = id;
		else
			Attributes.mapID = 1;

		LoadTextDefficulty ();
		SetTriggerSelectMap ();
		Debug.Log ("SELECTED MAP: " + Attributes.mapID);
	}

	// Chon Difficulty
	public void SelectDifficulty(int dif) {
		//Sound
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.CLICK_BUTTON);
		}

		if (dif > 0 && dif < 4)
			Attributes.difficulty = dif;
		else
			Attributes.difficulty = 1;
		Debug.Log ("DEFFI: " + Attributes.difficulty);

		GotoMap ();
	}
	
	public void BackMainMenu() {
		LoadScene.Load (Strings.SCEN_MENU);
	}

	public void BackSelectMap() {
		SetTriggerSelectDifficulty ();
	}

	void SetTriggerSelectMap() {
		map1Anim.SetTrigger ("CloseMap1");
		map2Anim.SetTrigger ("CloseMap2");
		map3Anim.SetTrigger ("CloseMap3");
	}

	void SetTriggerSelectDifficulty() {
		dif1Anim.SetTrigger ("CloseMap1");
		dif2Anim.SetTrigger ("CloseDif2");
		dif3Anim.SetTrigger ("CloseMap3");
	}

	private void GotoMap(){
		switch (Attributes.mapID) {
			case 1:
				//GOTO Map 1
				LoadScene.Load(Strings.SCEN_GAMEPLAY_MAP1);
				break;
			case 2:
				//GOTO Map 2
				LoadScene.Load(Strings.SCEN_GAMEPLAY_MAP2);
				break;
			case 3:
				//GOTO Map 3
				LoadScene.Load(Strings.SCEN_GAMEPLAY_MAP3);
				break;
			default:
				//GOTO Map 1
				LoadScene.Load(Strings.SCEN_GAMEPLAY_MAP1);
				break;
		}
	}

	private void LoadTextDefficulty(){
		switch (Attributes.mapID) {
		case 1:
			LoadTextMap1();
			break;
		case 2: 
			LoadTextMap2();
			break;
		case 3:
			LoadTextMap3();
			break;
		default:
			LoadTextMap1();
			break;

		}
	}

	private void LoadTextMap1(){
		textEasy.text = " 5 ATTACKS \n SPEED ENEMY: 0.75% \n SCORE BONUS 0%";
		textMedium.text = " 5 ATTACKS \n SPEED ENEMY: 1.25% \n SCORE BONUS 40%";
		textHard.text = " 5 ATTACKS \n SPEED ENEMY: 1.75% \n SCORE BONUS 60%";
	}

	private void LoadTextMap2(){
		textEasy.text = " 5 ATTACKS \n SPEED ENEMY: 0.75% \n SCORE BONUS 0%";
		textMedium.text = " 5 ATTACKS \n SPEED ENEMY: 1.25% \n SCORE BONUS 40%";
		textHard.text = " 5 ATTACKS \n SPEED ENEMY: 1.75% \n SCORE BONUS 60%";
	}

	private void LoadTextMap3(){
		textEasy.text = " 10 ATTACKS \n SPEED ENEMY: 0.75% \n SCORE BONUS 0%";
		textMedium.text = " 10 ATTACKS \n SPEED ENEMY: 1.25% \n SCORE BONUS 40%";
		textHard.text = " 10 ATTACKS \n SPEED ENEMY: 1.75% \n SCORE BONUS 60%";
	}
}
