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
			NotePlayer();
		}
    }

    void OnMouseUp() {
		Debug.Log ("Cham mia roi");
        if (canPlacePlayer())
        {
            Debug.Log("Co the dat duoc player");
            parentPlayer.SetPlayer(playerPrefab);
            parentPlayer.CloseListPlayer();
        }
    }

    private bool canPlacePlayer() {
        Debug.Log("Gold manager: " + GameManager.instance.Gold);
        cost = playerPrefab.GetComponent<PlayerData>().levels[0].cost;
        return player == null && GameManager.instance.Gold >= cost;
    }

    private void LoadSpritePlayer() {
		gameObject.transform.FindChild ("PlayerImage").gameObject.GetComponent<SpriteRenderer> ().sprite = 
			playerPrefab.GetComponent<PlayerData> ().levels [0].visualization.GetComponent<SpriteRenderer> ().sprite;
    }

	private void NotePlayer(){
		gameObject.SetActive (false);
	}
}
