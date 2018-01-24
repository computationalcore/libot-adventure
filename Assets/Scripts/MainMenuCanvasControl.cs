using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Setup the main menu canvas behavior based on device the game is running.
/// </summary>
public class MainMenuCanvasControl : MonoBehaviour {

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		// Check if the device running is desktop or Apple TV.
		if ((SystemInfo.deviceType != DeviceType.Desktop && (Application.platform != RuntimePlatform.tvOS)) || (Application.platform == RuntimePlatform.WebGLPlayer)) {
			GameObject quitButton = GameObject.Find ("Quit Button");
			quitButton.SetActive (false);
		}
		// Hide Open Github button if device is Apple TV since open an external link does not work for default at this platform.
		if (Application.platform == RuntimePlatform.tvOS) {
			GameObject openGithubButton = GameObject.Find("Open Github Button");
			openGithubButton.SetActive (false);
			// Move quit button position to the open github button position.
			GameObject quitButton = GameObject.Find ("Quit Button");
			quitButton.transform.transform.localPosition = new Vector3(0.0f, -180.0f, 0.0f);
		}
	}
}
