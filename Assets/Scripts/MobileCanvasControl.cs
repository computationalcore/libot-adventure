using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileCanvasControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Check if the device running this is a handheld and show jostick control.
		if ( (SystemInfo.deviceType != DeviceType.Handheld) || (Application.platform == RuntimePlatform.tvOS)) {
			this.gameObject.SetActive (false);
		}
	}
}
