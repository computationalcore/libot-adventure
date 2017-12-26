using UnityEngine;
using System.Collections;


public class UIButtonOpenGithub : MonoBehaviour {

	public void openGithub() {
		//Open the project github page
		Application.OpenURL("https://github.com/computationalcore/sphero-adventure/");
	}

}