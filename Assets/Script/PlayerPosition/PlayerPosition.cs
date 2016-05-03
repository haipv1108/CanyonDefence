using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerPosition : MonoBehaviour {

    public PlayerType playerType;
    public GameObject playerPrefab;
    public PlacePlayer parentPlayer;
    private GameObject player;
    private int cost;

    void Start() {
        LoadSpritePlayer();
    }

    void Update() {
        //Check neu tien du de mua player nay hay khong?
		if (!canPlacePlayer ()) {
			NoteDeActivePlayer ();
		} else {
			NoteActivePlayer();
		}
    }

    void OnMouseUp() {
        if (canPlacePlayer())
        {
            Debug.Log("Co the dat duoc player");
            parentPlayer.SetPlayer(playerPrefab);
			Debug.Log("Nhu cc");
            parentPlayer.CloseListPlayer();
			Debug.Log("Nhu cc2");
        }
    }

    private bool canPlacePlayer() {
        cost = playerPrefab.GetComponent<PlayerData>().levels[0].cost;
        return player == null && GameManager.instance.Gold >= cost;
    }

    private void LoadSpritePlayer() {
		gameObject.transform.FindChild ("PlayerImage").gameObject.GetComponent<SpriteRenderer> ().sprite = 
			playerPrefab.GetComponent<PlayerData> ().levels [0].visualization.GetComponent<SpriteRenderer> ().sprite;
    }

	private void NoteDeActivePlayer(){
		//gameObject.SetActive (false);
		gameObject.GetComponent<SpriteRenderer> ().color = new Color (1f, 1f, 1f, 0.3f);
		gameObject.transform.FindChild("PlayerImage").gameObject.GetComponent<SpriteRenderer>().color = new Color (1f, 1f, 1f, 0.3f);
	}

	private void NoteActivePlayer(){
		gameObject.SetActive (true);
	}
}
