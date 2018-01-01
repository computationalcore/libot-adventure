using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCanvasControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject mobileJostick = GameObject.FindGameObjectWithTag ("MobileJostick");
		// Check if the device running this is a handheld and show jostick control.
		if (SystemInfo.deviceType == DeviceType.Handheld) {
			// Set the correct size and position of the button dependent of the screen size 
			float jostickSize = Screen.height * 0.30f;
			float handleSize = jostickSize * 0.5f;
			float position = (jostickSize / 2) + 20;


			GameObject jostickHandle = GameObject.FindGameObjectWithTag ("MobileJostickHandle");

			RectTransform rtJostick = mobileJostick.GetComponent<RectTransform> ();
			rtJostick.sizeDelta = new Vector2 (jostickSize, jostickSize);
			rtJostick.position = new Vector2 (position, position);

			RectTransform rtHandle = jostickHandle.GetComponent<RectTransform> ();
			rtHandle.sizeDelta = new Vector2 (handleSize, handleSize);
		} else {
			mobileJostick.SetActive (false);
		}
	}
}
