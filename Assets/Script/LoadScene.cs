using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

	public Image cooldown;
	public Text pecentLoading;
	public static string sceneToLoad = Strings.SCEN_MENU; // Default scene is main menu
	
	void Start()
	{
		StartCoroutine(Loading());
	}
	
	IEnumerator Loading()
	{
		AsyncOperation async = Application.LoadLevelAsync(sceneToLoad);
		while (!async.isDone)
		{
			cooldown.fillAmount = async.progress;
			float pecent = async.progress * 100;
			pecentLoading.text = pecent + " %";
			yield return (0);
		}
		Application.LoadLevel(sceneToLoad);

	}

	public static void Load(string scene)
	{
		if (scene != Strings.SCENE_LOADING)
		{
			sceneToLoad = scene;
			Application.LoadLevel(Strings.SCENE_LOADING);
		}
		else
		{
			// fail save loading main menu if scene is loading scene
			Load(Strings.SCEN_MENU);
		}
		
		
	}
}
