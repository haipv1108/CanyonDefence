using UnityEngine;
using System.Collections;

public class UpgradePosition : MonoBehaviour {

    public PlacePlayer placePlayer;

    void OnMouseUp() {
		if (GameManager.instance.gamestate == GAMESTATE.GAMEPLAYING) {
			placePlayer.CloseUpgradePopup();
			if (placePlayer.CanUpgradePlayer())
			{
				Debug.Log("Co the upgrade");
				placePlayer.GetPlayer().GetComponent<PlayerData>().increaseLevel();
				
				//TODO: Them am thanh upgrade
				if(SoundManager.instance != null){
					SoundManager.instance.PlaySFX(SFX.UPGRADE_PLAYER);
				}
				GameManager.instance.Gold -= placePlayer.GetPlayer().GetComponent<PlayerData>().CurrentLevel.cost;
			}
			Debug.Log("The eo nao eo upgrade duoc");
		}
    }
}
