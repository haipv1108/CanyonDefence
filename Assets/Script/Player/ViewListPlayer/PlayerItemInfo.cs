using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerItemInfo : MonoBehaviour {

    public Text goldText;
    public Text descriptionText;
    public Image image;

    public void LoadPlayerInfo(PlayerInfo playerInfo) {
        this.goldText.text = playerInfo.gold.ToString();
        this.descriptionText.text = playerInfo.description;
        this.image.sprite = playerInfo.sprite;
    }
}
