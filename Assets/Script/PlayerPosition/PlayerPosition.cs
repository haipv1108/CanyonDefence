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
        Debug.Log("Khoi dong");
        //TODO: Cap nhat hinh anh cho cac playerImage
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
        Debug.Log("Gold can mua: " + cost);
        return player == null && GameManager.instance.Gold >= cost;
    }

    private void LoadSpritePlayer() {
        //playerPrefab.GetComponent<PlayerData>().levels[0].visualization.GetComponent<SpriteRenderer>();
        //playerPrefab.GetComponent<PlayerData>().levels[0].visualization.GetComponent<SpriteRenderer>().sprite;
        Debug.Log("Nhu cec: " + playerPrefab.GetComponent<PlayerData>().levels[0].visualization.GetComponent<SpriteRenderer>().sprite);
    }
}
