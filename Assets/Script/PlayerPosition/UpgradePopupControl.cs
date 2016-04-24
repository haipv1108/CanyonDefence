using UnityEngine;
using System.Collections;

public class UpgradePopupControl : MonoBehaviour {

    public PlacePlayer placePlayer;
    public GameObject upPopup;
    public GameObject sellPopup;
    public GameObject maxPopup;

    void Update() {
        //Kiem tra cac popup duoc phep hien thi
        CheckActivePopup();
    }

    public void Open() {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void CheckActivePopup() {
        if (placePlayer.IsLevelMax()) {
            upPopup.SetActive(false);
            maxPopup.SetActive(true);
            sellPopup.SetActive(true);
        }
        if (placePlayer.CanUpgradePlayer())
        {
            upPopup.SetActive(true);
            maxPopup.SetActive(false);
            sellPopup.SetActive(true);
        }
        //TODO: Doi mau uppopup khi khong nang cap duoc do thieu tien
    }
	
}
