using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class UIButtonExitTutorial : MonoBehaviour {


	private GameObject mainMenu;
	private GameObject tutorialLight;
	private GameObject tutorialGameElements;
	private GameObject tutorialCanvas;
	private GameObject exitTutorialButton;
	private Transform mainCameraTarget;
	private GameObject mainMenuCameraTarget;
	private GameObject tutorialCameraTarget;

	private enum cameraPositions {Tutorial, MainMenu, None};
	private cameraPositions cameraPosition = cameraPositions.Tutorial;

}