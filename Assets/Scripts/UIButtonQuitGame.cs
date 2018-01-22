using UnityEngine;
using System.Collections;

/// <summary>
/// Quit Button click handler.
/// </summary>
public class UIButtonQuitGame : MonoBehaviour {

	/// <summary>
	/// Quit game application.
	/// </summary>
	public void quitGame()
	{
		// Closes the game.
		Application.Quit();
	}
}