﻿using UnityEngine;
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
        
    }


    public void createPlayer() {
        
    }

    void OnMouseUp() {
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

		int coin = playerPrefab.GetComponent<PlayerData> ().levels [0].cost;
		if (coin > GameManager.instance.Gold) {
			gameObject.SetActive (false);
		} else {
			gameObject.transform.FindChild ("PlayerImage").gameObject.GetComponent<SpriteRenderer> ().sprite = 
				playerPrefab.GetComponent<PlayerData> ().levels [0].visualization.GetComponent<SpriteRenderer> ().sprite;
		}
    }
}
