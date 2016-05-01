using UnityEngine;
using System.Collections;

public class TestSoundManager : MonoBehaviour {

	public SettingSound settingSoundGameObject; 

	void Start(){
		settingSoundGameObject.Close ();
	}

	void Update(){
		if (Input.anyKey) {
			settingSoundGameObject.Open();
		}
	}

	public void TestBGM(){
		if (SoundManager.instance != null) {
			SoundManager.instance.PlayBGM(BGM.MENU);
		}
	}

	public void PauseBGM(){
		if (SoundManager.instance != null) {
			SoundManager.instance.PauseBGM(BGM.MENU);
		}
	}

	public void TestSFX(){
		if (SoundManager.instance != null) {
			SoundManager.instance.PlaySFX(SFX.VICTORY);
		}
	}

	public void PauseSFX(){
		if (SoundManager.instance != null) {
			SoundManager.instance.PauseSFX(SFX.VICTORY);
		}
	}
}
