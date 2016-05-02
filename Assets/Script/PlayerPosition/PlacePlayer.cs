using UnityEngine;
using System.Collections;

public class PlacePlayer : MonoBehaviour {

	public static PlacePlayer instance;
    public GameObject playerPrefab;
    public GameObject listPlayer;
    public UpgradePopupControl upgradeGameObject;
    private GameObject player;

	public static GameObject gameObjectActive;
	public static UpgradePopupControl upgradeGameObjectActive;

	public static bool isActivePopup = false;

    // Khi click chuot xuong, se hien thi danh sach cac player co the dat xuong. 
    //Nguoi dung se chon player de cai dat

	void Awake(){
		instance = this;
	}

    void OnMouseUp() {
        //
		Debug.Log ("ONMOUSE UP");
		if (!isActivePopup) {
			if (player == null)
			{
				listPlayer.SetActive(true);
				isActivePopup = true;
				gameObjectActive = listPlayer;
			} else {
				//TODO: Xu ly o upgrade popup
				isActivePopup = true;
				upgradeGameObject.Open();
				upgradeGameObjectActive = upgradeGameObject;
			}
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
		isActivePopup = false;
    }

    public void CloseUpgradePopup() {
		isActivePopup = false;
        upgradeGameObject.Close();
    }

    public GameObject GetPlayer() {
        return player;
    }

	public void CloseAllPopup(){
		if (gameObjectActive != null) {
			gameObjectActive.SetActive (false);
		}
		if(upgradeGameObjectActive != null)
			upgradeGameObjectActive.Close ();
		isActivePopup = false;
	}
}
