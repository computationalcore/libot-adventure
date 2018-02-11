using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Setup the main menu canvas behavior based on device the game is running.
/// </summary>
public class MainMenu : MonoBehaviour {

	// Tutorial related game objects
	public GameObject coin;
	public GameObject crate;
	public GameObject stoneMonster;
	public GameObject tutorialCanvas;
	public GameObject tutorialGameElements;
	public GameObject menuCanvas;
	public GameObject nextButton;
	public GameObject backButton;
	public Text elementTitle;
	public Text elementDescription;

	public GameObject mainMenu;
	public GameObject gameDifficultyCanvas;
	public GameObject tutorialLight;
	public Transform mainMenuCameraTarget;
	public Transform tutorialCameraTarget;
	public Transform settingsCameraTarget;
	public Transform gameDifficultyCameraTarget;
	public Transform mainCameraTarget;

	private enum cameraPositions {Difficulty, MainMenu, Settings, Tutorial};
	private cameraPositions cameraPosition = cameraPositions.Tutorial;

	private Dictionary<cameraPositions, Transform> availableCameraPositions;
	private Transform selectedCameraPosition;




	// Tutorial 
	private Transform tutorialTarget;

	private int targetIndex = 0;


	// Tutorial Elements
	private GameObject[] availableTutorialTargets;
	private string[] availableTutorialTitle;
	private string[] availableTutorialDescription;

	// starting value for the Lerp
	private float t = 0.0f;
	private float timeToMove = 1.0f;

	void Awake()
	{
		availableTutorialTargets = new GameObject[] { coin, crate, stoneMonster };
		availableTutorialTitle = new string[] { "Coin", "Mystic Crate", "Stone Monster" };
		availableTutorialDescription = new string[] { 
			"To complete the level you must collect a certain number of this coins, indicated when each level starts",
			"You must avoid touching this crates, they are enemies that chases you over the game",
			"This enemy chases you when you gets a certain distance from it and try to bite. They pass through any solid, including rocks and the ground."
		};
		//tutorialTarget = availableTutorialTargets [targetIndex].transform;
		SetTarget (targetIndex);

		// Use Dictionary as a map.
		availableCameraPositions = new Dictionary<cameraPositions, Transform>();

		// ... Add some keys and values.
		availableCameraPositions.Add(cameraPositions.MainMenu, mainMenuCameraTarget);
		availableCameraPositions.Add(cameraPositions.Tutorial, tutorialCameraTarget);
		availableCameraPositions.Add(cameraPositions.Difficulty, mainMenuCameraTarget);
		availableCameraPositions.Add(cameraPositions.Settings, settingsCameraTarget);
	}

	void Start() {
		goToTutorial ();
	}

	public void goToMainMenu() {
		// Set up the Tutorial elements.
		mainMenu.SetActive (true);
		tutorialLight.SetActive (false);
		tutorialGameElements.SetActive (false);
		tutorialCanvas.SetActive (false);
		gameDifficultyCanvas.SetActive (false);

		cameraPosition = cameraPositions.MainMenu;
		t = 0.0f;
	}

	public void goToTutorial() {
		targetIndex = 0;
		SetTarget (targetIndex);

		// Set up the Tutorial elements.
		tutorialLight.SetActive (true);
		tutorialGameElements.SetActive (true);
		tutorialCanvas.SetActive (true);
		mainMenu.SetActive (false);
		gameDifficultyCanvas.SetActive (false);
		cameraPosition = cameraPositions.Tutorial;
		t = 0.0f;
	}

	public void goToSettings() {
		// Set up the Tutorial elements.
		tutorialLight.SetActive (false);
		tutorialGameElements.SetActive (false);
		tutorialCanvas.SetActive (false);
		mainMenu.SetActive (true);
		cameraPosition = cameraPositions.Settings;
		t = 0.0f;
	}

	public void goToGameDifficulty() {
		// Set up the Tutorial elements.
		gameDifficultyCanvas.SetActive (true);
		mainMenu.SetActive (false);
		cameraPosition = cameraPositions.Difficulty;
		t = 0.0f;
	}

	void LateUpdate() {

		if (cameraPosition == cameraPositions.Tutorial) {
			mainCameraTarget.position = new Vector3 (
				Mathf.Lerp (mainCameraTarget.position.x, tutorialCameraTarget.transform.position.x, t), 
				Mathf.Lerp (mainCameraTarget.position.y, tutorialCameraTarget.transform.position.y, t),
				Mathf.Lerp (mainCameraTarget.position.z, tutorialTarget.transform.position.z, t)
			);
		} else {
			mainCameraTarget.position = Vector3.Lerp(mainCameraTarget.position, availableCameraPositions[cameraPosition].position, t);
		}

		mainCameraTarget.rotation = Quaternion.Euler (
			Mathf.LerpAngle (mainCameraTarget.eulerAngles.x, availableCameraPositions[cameraPosition].transform.eulerAngles.x, t),
			Mathf.LerpAngle (mainCameraTarget.eulerAngles.y, availableCameraPositions[cameraPosition].transform.eulerAngles.y, t),
			Mathf.LerpAngle (mainCameraTarget.eulerAngles.z, availableCameraPositions[cameraPosition].transform.eulerAngles.z, t)
		);

		// now check if the interpolator has reached 1.0
		// and swap maximum and minimum so game object moves
		// in the opposite direction.
		if (t < 1.0f) {
			// .. increate the t interpolater
			t += Time.deltaTime / timeToMove;
		} else {
			t = 1.0f;
		}
	}


	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void goToNext() {
		if (targetIndex == availableTutorialTargets.Length - 1 )
			return;
		targetIndex += 1;
		SetTarget (targetIndex);

	}

	public void goBack() {
		if (targetIndex == 0)
			return;
		targetIndex -= 1;
		SetTarget (targetIndex);
	}

	private void SetTarget(int targetIndex) {
		if (targetIndex == 0) {
			backButton.SetActive (false);
			nextButton.SetActive (true);
		} else if (targetIndex == availableTutorialTargets.Length - 1) {
			nextButton.SetActive (false);
		} else {
			backButton.SetActive (true);
			nextButton.SetActive (true);
		}

		tutorialTarget = availableTutorialTargets [targetIndex].transform;
		elementTitle.text = availableTutorialTitle [targetIndex];
		elementDescription.text = availableTutorialDescription [targetIndex];
		// resets the lerp interpolater.
		t = 0.0f;
	}

}
