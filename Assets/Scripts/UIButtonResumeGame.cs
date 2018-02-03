using UnityEngine;
using System.Collections;

/// <summary>
/// Resume Game handler.
/// </summary>
public class UIButtonResumeGame : MonoBehaviour {

	/// <summary>
	/// Resume the game after paused.
	/// </summary>
	public void resumeGame()
	{
		// Closes the game.
		Time.timeScale = 1;
	}
}