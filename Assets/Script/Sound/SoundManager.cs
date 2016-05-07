using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource bgm;
	public AudioSource sfx;
	public BGMEntry[] bgms;
	public SFXEntry[] sfxs;

	private bool isChangeBGMVolume;
	private bool isChangeSFXVolume;

	private AudioSource secondarySFX;

	private AudioSource sfxSource{
		get{
			if(!sfx.isPlaying) return sfx;
			if(secondarySFX == null)
				secondarySFX = (new GameObject("SFX")).AddComponent<AudioSource>();
			return secondarySFX;
		}
	}

	void Awake(){
		instance = this;
		isChangeBGMVolume = false;
		isChangeSFXVolume = false;
	}

	public void PlayBGM(BGM bgmName){
		if (Attributes.isSoundBGOn ()) {
			foreach(BGMEntry entry in bgms){
				if(entry.name == bgmName){
					bgm.clip = entry.music;
					bgm.volume = Attributes.getBGMVolume();
					bgm.Play();
					return;
				}
			}
		}
	}

	public void PauseBGM(BGM bgmName){
		if (Attributes.isSoundBGOn ()) {
			foreach(BGMEntry entry in bgms){
				if(entry.name == bgmName){
					bgm.clip = entry.music;
					bgm.Pause();
				}
			}
		}
	}

	public void PlaySFX(SFX sfxName){
		if (Attributes.isSoundSFXOn ()) {
			foreach(SFXEntry entry in sfxs){
				if(entry.name == sfxName){
					sfx.clip = entry.sound;
					sfx.volume = Attributes.getSFXVolume();
					sfx.Play();
					return;
				}
			}
		}
	}

	public void PauseSFX(SFX sfxName){
		if (Attributes.isSoundSFXOn ()) {
			foreach(SFXEntry entry in sfxs){
				if(entry.name == sfxName){
					sfx.clip = entry.sound;
					sfx.Pause();
				}
			}
		}
	}

	void Update(){
		if (isChangeBGMVolume) {
			bgm.volume = Attributes.getBGMVolume ();
			isChangeBGMVolume = false;
		}
		if (isChangeSFXVolume) {
			sfx.volume = Attributes.getSFXVolume ();
			isChangeSFXVolume = false;
		}
	}

	public void ChangeBGMVolume(){
		isChangeBGMVolume = true;
	}

	public void ChangeSFXVolume(){
		isChangeSFXVolume = true;
	}
}

public enum BGM{
	MENU,
	SELECT_MAP,
	GAMEPLAY
}

public enum SFX{
	OPEN_DIALOG,
	CLICK_BUTTON,
	PLAYER_PLACE,
	SELL_PLAYER,
	UPGRADE_PLAYER,
	PLAYER_DIE,
	ENEMY_DIE,
	VICTORY,
	LOSE_GAME,
	THREE,
	TWO,
	ONE,
	START
}

[System.Serializable]
public struct BGMEntry{
	public BGM name;
	public AudioClip music;
}

[System.Serializable]
public struct SFXEntry{
	public SFX name;
	public AudioClip sound;
}

