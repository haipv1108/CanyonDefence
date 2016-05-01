using UnityEngine;
using System.Collections;

public class ShakeCamera : MonoBehaviour {

	public Camera camera;
	public bool shakePosition;
	public bool shakeRotation;
	
	public float shakeIntensity = 0.5f; 
	public float shakeDecay = 0.02f;
	
	private Vector3 OriginalPos;
	private Quaternion OriginalRot;
	
	private bool isShakeRunning = false;

	public void DoShake()
	{
		OriginalPos = camera.transform.position;
		OriginalRot = camera.transform.rotation;
		
		StartCoroutine ("ProcessShake");
	}

	IEnumerator ProcessShake()
	{
		if (!isShakeRunning) {
			isShakeRunning = true;
			float currentShakeIntensity = shakeIntensity;
			
			while (currentShakeIntensity > 0) {
				if (shakePosition) {
					camera.transform.position = new Vector3(Random.insideUnitSphere.x * currentShakeIntensity, camera.transform.position.y ,camera.transform.position.z);
					// just change the float values of the Vector3 Component to Random.insideUnitSphere.x/y/z where you see fit.
				}
				if (shakeRotation) {
					camera.transform.rotation = new Quaternion (OriginalRot.x + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
					                                     OriginalRot.y + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
					                                     OriginalRot.z + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f,
					                                     OriginalRot.w + Random.Range (-currentShakeIntensity, currentShakeIntensity) * .2f);
				}
				currentShakeIntensity -= shakeDecay;
				yield return null;
			}
			
			isShakeRunning = false;
		}
	}
}
