using UnityEngine;
using System.Collections;

public class PlacePlayer : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject listPlayer;
    public UpgradePopupControl upgradeGameObject;
    private GameObject player;

    // Khi click chuot xuong, se hien thi danh sach cac player co the dat xuong. 
    //Nguoi dung se chon player de cai dat

    void OnMouseUp() {
        //
        if (player == null)
        {
            Debug.Log("Click vao roi");
            listPlayer.SetActive(true);
        } else {
            //TODO: Xu ly o upgrade popup
            upgradeGameObject.Open();

        }
    }

    public bool CanUpgradePlayer() {
        if (player != null) {
            PlayerData currentPlayer = player.GetComponent<PlayerData>();
            PlayerLevel nextLevel = currentPlayer.getNextLevel();
            if (nextLevel != null) {
                return GameManager.instance.gold >= nextLevel.cost;
            }
        }
        return false;
    }

    public bool IsLevelMax() {
        if (player != null) {
            PlayerData currentPlayer = player.GetComponent<PlayerData>();
            PlayerLevel nextLevel = currentPlayer.getNextLevel();
            if (nextLevel == null)
                return true;
        }
        return false;
    }

    public void SetPlayer(GameObject playerPrefab) {
        this.playerPrefab = playerPrefab;
        player = (GameObject)Instantiate(playerPrefab, transform.position, Quaternion.identity);
        //TODO: Tru tien gamemanager
        GameManager.instance.Gold -= player.GetComponent<PlayerData>().CurrentLevel.cost;
    }

    public void SellPlayer() {
        //TODO: Them tien
        Destroy(player);
    }

    public void CloseListPlayer() {
        listPlayer.SetActive(false);
    }

    public void CloseUpgradePopup() {
        upgradeGameObject.Close();
    }

    public GameObject GetPlayer() {
        return player;
    }
	
}
