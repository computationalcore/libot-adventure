using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class UIButtonStartGame : MonoBehaviour {

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void loadLevelEasy() {
		GameSettings.difficulty = GameSettings.gameDifficulties.Easy;
		GameSettings.showIntroLevelMessage = true;
		SceneManager.LoadScene ("Level1");
	}

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void loadLevelNormal() {
		GameSettings.difficulty = GameSettings.gameDifficulties.Normal;
		GameSettings.showIntroLevelMessage = true;
		SceneManager.LoadScene ("Level1");
	}

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void loadLevelHard() {
		GameSettings.difficulty = GameSettings.gameDifficulties.Hard;
		GameSettings.showIntroLevelMessage = true;
		SceneManager.LoadScene ("Level1");
	}

}