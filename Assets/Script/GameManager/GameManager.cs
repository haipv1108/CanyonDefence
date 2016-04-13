using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public int gold = 1000;

	void Awake(){
		instance = this;
	}
}
