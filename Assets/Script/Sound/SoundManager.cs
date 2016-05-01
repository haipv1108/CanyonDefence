using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public AudioSource bgm;
	public AudioSource sfx;
	public BGMEntry[] bgms;
	public SFXEntry[] sfxs;

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
	}

	public void PlayBGM(BGM bgmName){
		if (Attributes.isSoundBGOn ()) {
			foreach(BGMEntry entry in bgms){
				if(entry.name == bgmName){
					bgm.clip = entry.music;
					bgm.Play();
					return;
				}
			}
		}
	}

	public void PlaySFX(SFX sfxName){
		if (Attributes.isSoundSFXOn ()) {
			foreach(SFXEntry entry in sfxs){
				if(entry.name == sfxName){
					sfx.clip = entry.sound;
					sfx.Play();
					return;
				}
			}
		}
	}

}

public enum BGM{
	MENU,
	SELECT_MAP,
	SELECT_DIFFICULTY,
	GAMEPLAY
}

public enum SFX{
	OPEN_DIALOG,
	CLICK_BUTTON
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

