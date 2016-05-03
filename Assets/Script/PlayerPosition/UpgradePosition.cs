using UnityEngine;
using System.Collections;

public class UpgradePosition : MonoBehaviour {

    public PlacePlayer placePlayer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseUp() {
        placePlayer.CloseUpgradePopup();
        if (placePlayer.CanUpgradePlayer())
        {
            Debug.Log("Co the upgrade");
            placePlayer.GetPlayer().GetComponent<PlayerData>().increaseLevel();

            //TODO: Them am thanh upgrade
            GameManager.instance.Gold -= placePlayer.GetPlayer().GetComponent<PlayerData>().CurrentLevel.cost;
        }
        Debug.Log("The eo nao eo upgrade duoc");
    }
}
