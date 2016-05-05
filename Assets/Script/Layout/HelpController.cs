using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HelpController : MonoBehaviour {

	public Sprite[] HelpImgSprites;
	public GameObject helpImg;
	public GameObject helpText;
	private int idHelpImg;
	
	void Start() {
		SetDefaultImage ();
	}

	void SetDefaultImage() {
		idHelpImg = -1;
		helpText.SetActive (true);
		helpImg.SetActive (false);
	}
	
	// Click Next Button on Help Popup
	public void OnClickNextHelp()
	{
		if ( (idHelpImg + 1) > -1 && (idHelpImg + 1) < HelpImgSprites.Length) {
			idHelpImg++;
			helpText.SetActive (false);
			helpImg.SetActive (true);
			helpImg.GetComponent<Image>().sprite = HelpImgSprites[idHelpImg];
		}
	}
	
	// Click Back Button on Help Popup
	public void OnClickBackHelp()
	{
		if ((idHelpImg - 1) >= -1) {
			idHelpImg--;
			if(idHelpImg == -1) {
				helpText.SetActive (true);
				helpImg.SetActive (false);
			} else
				helpImg.GetComponent<Image>().sprite = HelpImgSprites[idHelpImg];
		}
	}
}
