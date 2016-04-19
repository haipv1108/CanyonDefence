using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerItemInfo : MonoBehaviour {

    public Text goldText;
    public Text descriptionText;
    public Image image;
    public GameObject descriptionObject;
    public Text descriptionButtonText;

    public void LoadPlayerInfo(PlayerInfo playerInfo) {
        this.goldText.text = playerInfo.gold.ToString();
        this.descriptionText.text = playerInfo.description;
        this.image.sprite = playerInfo.sprite;
    }

    public void ActiveDescription() {
        if (!descriptionObject.activeSelf)
        {
            descriptionObject.SetActive(true);
            descriptionButtonText.text = "[X]";
            descriptionButtonText.color = Color.red;
        }
        else {
            descriptionObject.SetActive(false);
            descriptionButtonText.text = "[?]";
            descriptionButtonText.color = Color.white;
        }
    }

}
