using UnityEngine;
using System.Collections;

/// <summary>
/// Open Github Button click handler.
/// </summary>
public class UIButtonOpenGithub : MonoBehaviour {

	/// <summary>
	/// Open the project github page on the device default browser.
	/// </summary>
	public void openGithub() {
		//Open the project github page
		Application.OpenURL("https://github.com/computationalcore/libot-adventure/");
	}

}