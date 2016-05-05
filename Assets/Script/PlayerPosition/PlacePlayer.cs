using UnityEngine;
using System.Collections;

public class PlacePlayer : MonoBehaviour {

	public static PlacePlayer instance;
    public GameObject playerPrefab;
    public GameObject listPlayer;
    public UpgradePopupControl upgradeGameObject;
    public GameObject player;

	public static GameObject currentGameObject;
	public static GameObject gameObjectActive;
	public static UpgradePopupControl upgradeGameObjectActive;

	public static bool isActivePopup = false;

    // Khi click chuot xuong, se hien thi danh sach cac player co the dat xuong. 
    //Nguoi dung se chon player de cai dat

	void Awake(){
		instance = this;
		player = null;
	}

    void OnMouseUp() {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING) {
			if (currentGameObject != gameObject) {
				CloseAllPopup();
			}
			if (!isActivePopup) {
				currentGameObject = gameObject;
				if (player == null)
				{
					listPlayer.SetActive(true);
					isActivePopup = true;
					gameObjectActive = listPlayer;
				} else {
					isActivePopup = true;
					upgradeGameObject.Open();
					upgradeGameObjectActive = upgradeGameObject;
				}
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
        GameManager.instance.Gold -= player.GetComponent<PlayerData>().CurrentLevel.cost;
    }

    public void SellPlayer() {
		//Am thanh sell player
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.SELL_PLAYER);
		}
        Destroy(player);
    }

    public void CloseListPlayer() {
        listPlayer.SetActive(false);
		isActivePopup = false;
    }

    public void CloseUpgradePopup() {
		isActivePopup = false;
		if (upgradeGameObjectActive != null) {
			upgradeGameObjectActive = null;
		}
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
