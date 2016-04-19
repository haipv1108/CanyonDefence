using UnityEngine;
using System.Collections;

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
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/* ------------ Click Button ------------*/
	// Chon Map
	public void SelectMap(int id) {
		if (id >= 1 && id <= 3)
			Attributes.mapID = id;
		else
			Attributes.mapID = 1;

		SetTriggerSelectMap ();

//		print ("map: " + Attributes.mapID);
	}

	// Chon Difficulty
	public void SelectDifficulty(int dif) {
		if (dif > 0 && dif < 4)
			Attributes.difficulty = dif;
		else
			Attributes.difficulty = 1;
		//		print ("dif: " + Attributes.difficulty);

		// Loading Scen
		// Vao Gameplay
		Application.LoadLevel (Strings.SCEN_GAMEPLAY);
	}

	public void BackMainMenu() {
		Application.LoadLevel (Strings.SCEN_MENU);
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

}
