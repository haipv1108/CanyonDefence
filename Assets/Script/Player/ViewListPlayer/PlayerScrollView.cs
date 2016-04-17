using UnityEngine;
using System.Collections;

public class PlayerScrollView : MonoBehaviour {

    public Transform playersContainer;
    public GameObject playerInfoPrefab;

    public ViewPlayerInfo playerInfos;

    void Start() {
        LoadPlayerInfo();
    }

    private void LoadPlayerInfo() {
        foreach (PlayerInfo playerInfo in playerInfos.playerInfos) {
            GameObject gameObject = Instantiate(playerInfoPrefab) as GameObject;
            gameObject.GetComponent<PlayerItemInfo>().LoadPlayerInfo(playerInfo);
            gameObject.transform.SetParent(playersContainer);
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
    }
}
