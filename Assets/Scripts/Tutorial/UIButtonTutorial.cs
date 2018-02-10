using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class UIButtonTutorial : MonoBehaviour {

	private GameObject target;
	private GameObject mainMenu;
	private GameObject tutorialLight;
	private GameObject tutorialGameElements;
	private GameObject tutorialCanvas;
	private GameObject exitTutorialButton;
	private Transform mainCameraTarget;

	private bool animateCamera = false;

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void enterTutorial() {
		// Set up the Tutorial elements.
		tutorialLight.SetActive (true);
		tutorialGameElements.SetActive (true);
		tutorialCanvas.SetActive (true);
		exitTutorialButton.transform.position = new Vector3( exitTutorialButton.transform.position.x, -10000, exitTutorialButton.transform.position.z) ;
		animateCamera = true;
	}

	void Awake()
	{
		target = GameObject.FindGameObjectWithTag ("MainMenuCameraPosition");
		mainCameraTarget = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform>();
		mainMenu = GameObject.FindGameObjectWithTag ("MainMenu");
		tutorialLight = GameObject.FindGameObjectWithTag("TutorialLight");
		tutorialGameElements = GameObject.FindGameObjectWithTag ("TutorialGameElements");
		tutorialCanvas = GameObject.FindGameObjectWithTag ("TutorialCanvas");
		exitTutorialButton = GameObject.FindGameObjectWithTag ("TutorialExitCanvas");
	}

	void LateUpdate() {
		// Early out if we don't have a target
		if (!target)
			return;
		if (!animateCamera)
			return;
		mainCameraTarget.position = new Vector3 (
			Mathf.Lerp (mainCameraTarget.position.x, target.transform.position.x, 2 * Time.deltaTime), 
			Mathf.Lerp (mainCameraTarget.position.y, target.transform.position.y, 2 * Time.deltaTime),
			Mathf.Lerp (mainCameraTarget.position.z, target.transform.position.z, 2 * Time.deltaTime)
		);
		mainCameraTarget.rotation = Quaternion.Euler (
			Mathf.LerpAngle(mainCameraTarget.eulerAngles.x, target.transform.eulerAngles.x, 2 * Time.deltaTime),
			Mathf.LerpAngle(mainCameraTarget.eulerAngles.y, target.transform.eulerAngles.y, 2 * Time.deltaTime),
			Mathf.LerpAngle(mainCameraTarget.eulerAngles.z, target.transform.eulerAngles.z, 2 * Time.deltaTime)
		);
		mainMenu.SetActive (true);
		print ("N FOIIIIII");
		if (mainCameraTarget.position == target.transform.position) {
			animateCamera = false;
			exitTutorialButton.SetActive (false);
			print ("FOIIIIII");
		}
	}
}