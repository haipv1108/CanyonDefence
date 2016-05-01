﻿using UnityEngine;
using System.Collections;

public class Attributes {

	public static int mapID;		// 1, 2 or 3
	public static int difficulty;	// 1-de, 2-trung binh, 3-kho

	public static int sound_bg = PlayerPrefs.GetInt (Strings.SOUND_BG, IS_ON);
	public static int sound_sfx = PlayerPrefs.GetInt(Strings.SOUND_SFX, IS_ON);
	public static int vibration = PlayerPrefs.GetInt(Strings.VIBRATION, IS_ON);

	public static int IS_ON = 1;
	public static int IS_OFF = 0;


	// Kiem tra am thanh background
	public static bool isSoundBGOn(){
		if (sound_bg == IS_ON)
			return true;
		return false;
	}

	// Set sound Bg
	public static void setSoundBG(int sound){
		sound_bg = sound;
		PlayerPrefs.SetInt (Strings.SOUND_BG, sound_bg);
	}

	// Kiem tra am thanh sfx
	public static bool isSoundSFXOn(){
		if(sound_sfx == IS_ON)
			return true;
		return false;
	}

	//Set sound sfx
	public static void setSoundSFX(int sound){
		sound_sfx = sound;
		PlayerPrefs.SetInt (Strings.SOUND_SFX, sound_sfx);
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
}
