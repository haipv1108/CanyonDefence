using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Setting : MonoBehaviour {

	public Slider bgmSlider;
	public Slider sfxSlider;
	public Toggle vibrateToggle;
	public InputField usernameInputFeild;

	void Start(){
		LoadInfo ();
	}

	void Update(){
		if (bgmSlider.value != Attributes.getBGMVolume ()) {
			Attributes.setBGMVolume(bgmSlider.value);
		}
		if (sfxSlider.value != Attributes.getSFXVolume ()) {
			Attributes.setSFXVolume(sfxSlider.value);
		}
		if (vibrateToggle.isOn != Attributes.isVibrationOn ()) {
			settingVibra(vibrateToggle.isOn);
		}
		if (usernameInputFeild.text != Attributes.getUserName ()) {
			Attributes.setUserName(usernameInputFeild.text);
		}
	}

	private void LoadInfo(){
		//BGM
		bgmSlider.value = Attributes.getBGMVolume ();
		//SFX
		sfxSlider.value = Attributes.getSFXVolume ();
		//Vibration
		vibrateToggle.isOn = Attributes.isVibrationOn ();
		//Username
		usernameInputFeild.text = Attributes.getUserName ();
	}

	private void settingVibra(bool vi){
		if (vi) {
			Attributes.setVibration (Attributes.IS_ON);
		} else {
			Attributes.setVibration(Attributes.IS_OFF);
		}
	}
}
