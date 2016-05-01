using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour {

	public Slider bgmSlider;
	public Slider sfxSlider;

	void Start(){
		bgmSlider.value = Attributes.getBGMVolume ();
		sfxSlider.value = Attributes.getSFXVolume ();
	}

	void Update(){
		if (bgmSlider.value != Attributes.getBGMVolume ()) {
			Attributes.setBGMVolume(bgmSlider.value);
		}
		if (sfxSlider.value != Attributes.getSFXVolume ()) {
			Attributes.setSFXVolume(sfxSlider.value);
		}
	}

	public void Open(){
		gameObject.SetActive (true);
	}

	public void Close(){
		gameObject.SetActive (false);
	}
}
