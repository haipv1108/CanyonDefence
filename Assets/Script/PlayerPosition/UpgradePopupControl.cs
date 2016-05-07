using UnityEngine;
using System.Collections;

public class UpgradePopupControl : MonoBehaviour {

    public PlacePlayer placePlayer;
    public GameObject upPopup;
    public GameObject sellPopup;
    public GameObject maxPopup;

    void Update() {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING) {
			//Kiem tra cac popup duoc phep hien thi
			if (isOpen ())
				CheckActivePopup ();
			else {
				DeActiveAllPopup();
			}
		}
    }

    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

	public bool isOpen(){
		return gameObject.activeSelf ;
	}

    public void CheckActivePopup() {
		if (placePlayer.IsLevelMax ()) {
			upPopup.SetActive (false);
			maxPopup.SetActive (true);
			sellPopup.SetActive (true);
		} else {
			maxPopup.SetActive (false);
			sellPopup.SetActive (true);
			if (placePlayer.player.GetComponent<PlayerData> ().getCostNextLevel() < GameManager.instance.Gold) {
				//Lam mo object
				upPopup.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,1f);
				upPopup.SetActive (true);
			} else {
				upPopup.SetActive(true);
				upPopup.GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.3f);
			}
		}
    }

	private void DeActiveAllPopup(){
		upPopup.SetActive (false);
		maxPopup.SetActive (false);
		sellPopup.SetActive (false);
	}
	
}
