using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour {

	public Slider bgmSlider;
	public Slider sfxSlider;

	void Start(){
		bgmSlider.value = Attributes.getBGMVolume ();
		sfxSlider.value = Attributes.getSFXVolume ();
		bgmSlider.onValueChanged.AddListener (delegate {ValueChangeCheckBGM ();});
		sfxSlider.onValueChanged.AddListener (delegate {ValueChangeCheckSFX ();});
	}
	
	public void Close(){
		gameObject.SetActive (false);
	}

	public void Open(){
		gameObject.SetActive (true);
	}

	private void ValueChangeCheckBGM(){
		Attributes.setBGMVolume(bgmSlider.value);
	}
	
	private void ValueChangeCheckSFX(){
		Attributes.setSFXVolume(sfxSlider.value);
	}
}
