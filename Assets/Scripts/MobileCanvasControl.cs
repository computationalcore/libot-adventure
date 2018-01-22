using UnityEngine;
using System.Collections;

/// <summary>
/// Setup the mobile canvas behavior based on device the game is running.
/// </summary>
public class MobileCanvasControl : MonoBehaviour {

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		// Check if the device running this is not a handheld and hide jostick control. 
		// Note: AppleTV is listed as Handheld so need to check it separately. 
		if ( (SystemInfo.deviceType != DeviceType.Handheld) || (Application.platform == RuntimePlatform.tvOS)) {
			this.gameObject.SetActive (false);
		}
	}
}
