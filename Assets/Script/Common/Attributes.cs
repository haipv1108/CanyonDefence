using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using CGArt.Utils;

public class Attributes {

	public static int mapID;		// 1, 2 or 3
	public static int difficulty;	// 1-de, 2-trung binh, 3-kho

	public static int vibration = PlayerPrefs.GetInt(Strings.VIBRATION, IS_ON);
	public static float bgm_volume = PlayerPrefs.GetFloat(Strings.BGM_VOLUME, 1.0f);
	public static float sfx_volume = PlayerPrefs.GetFloat(Strings.SFX_VOLUME, 1.0f);
	public static string user_name = PlayerPrefs.GetString(Strings.USER_NAME, "");

	public static int watch_help = PlayerPrefs.GetInt (Strings.DATA_WATCH_HELP, IS_OFF);

	public static int IS_ON = 1;
	public static int IS_OFF = 0;

	public static int GetWatchHelp(){
		return watch_help;
	}

	public static void SetWatchHelp(){
		watch_help = IS_ON;
		PlayerPrefs.SetInt (Strings.DATA_WATCH_HELP, watch_help);
	}

	//Get vibration info
	public static bool isVibrationOn(){
		if (vibration == IS_ON)
			return true;
		return false;
	}

	// Set vibration
	public static void setVibration(int vib){
		vibration = vib;
		PlayerPrefs.SetInt (Strings.VIBRATION, vibration);
	}

	// Get BGM Level volume
	public static float getBGMVolume(){
		return bgm_volume;
	}

	// Set BGM Level volume
	public static void setBGMVolume(float volume){
		bgm_volume = volume;
		if (SoundManager.instance != null) {
			SoundManager.instance.ChangeBGMVolume();
		}
		PlayerPrefs.SetFloat (Strings.BGM_VOLUME, bgm_volume);
	}

	// Get SFX Level volume
	public static float getSFXVolume(){
		return sfx_volume;
	}

	// Set SFX Level volume
	public static void setSFXVolume(float volume){
		sfx_volume = volume;
		if (SoundManager.instance != null) {
			SoundManager.instance.ChangeSFXVolume();
		}
		PlayerPrefs.SetFloat (Strings.SFX_VOLUME, sfx_volume);
	}

	//Set username

	public static void setUserName(string name){
		user_name = name;
		PlayerPrefs.SetString (Strings.USER_NAME, user_name);
	}

	//Get username
	public static string getUserName(){
		return user_name;
	}

	public static List<string> getListDataScore(){
		List<string> list = new List<string> ();
		List<int> listScore = getListScore ();
		if (user_name == "") {
			int i = 1;
			foreach (int score in listScore) {
				string arrow = i + ". " + score;
				list.Add(arrow);
				i++;
			}
		} else {
			foreach (int score in listScore) {
				string arrow = user_name + ". " + score;
				list.Add(arrow);
			}
		}
		return list;
	}

	public static List<int> getListScore(){
		List<int> list = DataManager.instance.GetIntList(Strings.DATA_SCORE);
		if (list.Count != 0) {
			for(int i = 0; i < list.Count - 1; i++){
				for(int j = i+1; j < list.Count; j++){
					if(list[i] < list[j]){
						int temp = list[i];
						list[i] = list[j];
						list[j] = temp;
					}
				}
			}
		}
		return list;
	}

	public static void addScoreToList(int score){
		DataManager.instance.AddIntToList (Strings.DATA_SCORE, score);
	}

	public static void setScoreData(int score){
		DataManager.instance.AddIntToList (Strings.DATA_SCORE, score);
	}

}
