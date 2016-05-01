using UnityEngine;
using System.Collections;

public class UseFunction : MonoBehaviour {

	/*
	 * Rung dien thoai khi quan enemy qua thanh (minh thua)
	 * Chi can copy noi dung cua function, khong can copy ca function
	 * Cho doan copy vao dieu kien enemy di den cuoi man choi
	 */
	public void Vibration(){
		if (Attributes.isVibrationOn ()) {
			Handheld.Vibrate();
		}
	}
}
