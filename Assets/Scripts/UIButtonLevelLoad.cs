using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class UIButtonLevelLoad : MonoBehaviour {

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void loadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	/// <summary>
	/// Load the next level based on the build index of the active scene.
	/// </summary>
	public void loadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	/// <summary>
	/// Reload the current active level.
	/// </summary>
	public void reloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}