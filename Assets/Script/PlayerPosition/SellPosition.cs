using UnityEngine;
using System.Collections;

public class SellPosition : MonoBehaviour {

    public PlacePlayer placePlayer;

    void Start() {
        //TODO: Load thong tin se sell duoc bn
    }

    void OnMouseUp() {
        placePlayer.SellPlayer();
        int goldSell = CalGoldSell();
        GameManager.instance.Gold += goldSell;
        placePlayer.CloseUpgradePopup();
    }

    private int CalGoldSell() {
        int gold = (int)(placePlayer.GetPlayer().GetComponent<PlayerData>().CurrentLevel.cost * 50 / 100);
        return gold;
    }
}
