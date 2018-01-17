using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCanvasControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// Check if the device running this is desktop.
		if (SystemInfo.deviceType != DeviceType.Desktop) {
			this.gameObject.SetActive (false);
		}
	}
}
