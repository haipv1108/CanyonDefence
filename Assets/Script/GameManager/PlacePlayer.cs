using UnityEngine;
using System.Collections;

public class PlacePlayer : MonoBehaviour {

	public GameObject playerPrefab;
	private GameObject player;

	// Khi click chuot xuong, se hien thi danh sach cac player co the dat xuong. 
	//Nguoi dung se chon player de cai dat

	void OnMouseUp(){

	}

	//Kiem tra xem loai player nay co duoc dat xuong hay khong de hien thi hinh anh
	private bool CanPlacePlayer(PlayerType playerType){

		return false;
	}
	
	private bool CanUpgradePlayer(){
		if (player != null) {
			PlayerData currentPlayer = player.GetComponent<PlayerData>();
			PlayerLevel nextLevel = currentPlayer.getNextLevel();
			if(nextLevel != null){
				return GameManager.instance.gold >= nextLevel.cost;
			}
		}
		return false;
	}
	
}
