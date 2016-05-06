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
		bgmSlider.onValueChanged.AddListener (delegate {ValueChangeCheckBGM ();});
		sfxSlider.onValueChanged.AddListener (delegate {ValueChangeCheckSFX ();});
		vibrateToggle.onValueChanged.AddListener(delegate {ValueChangeVibration ();});
		usernameInputFeild.onValueChange.AddListener(delegate {ValueChangeName ();});
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

	private void ValueChangeCheckBGM(){
		Attributes.setBGMVolume(bgmSlider.value);
	}

	private void ValueChangeCheckSFX(){
		Attributes.setSFXVolume(sfxSlider.value);
	}

	private void ValueChangeVibration(){
		if (vibrateToggle.isOn) {
			Attributes.setVibration (Attributes.IS_ON);
		} else {
			Attributes.setVibration(Attributes.IS_OFF);
		}
		Debug.Log ("Trang thai: " + Attributes.isVibrationOn());
	}

	private void ValueChangeName(){
		Attributes.setUserName(usernameInputFeild.text);
		Debug.Log ("Name: " + Attributes.getUserName());
	}
}
