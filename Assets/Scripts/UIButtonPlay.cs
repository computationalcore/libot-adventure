using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class UIButtonPlay : MonoBehaviour {

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void showDifficultCanvas(GameObject difficultCanvas) {
		GameObject.FindWithTag ("MainMenu").SetActive (false);
		difficultCanvas.SetActive (true);
		// Set Easy Button as selected.
		GameObject myEventSystem = GameObject.Find("EventSystem");
		myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (GameObject.Find ("Easy Button"));
	}
}