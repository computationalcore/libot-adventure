using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtonLevelLoad : MonoBehaviour {

	// Load a level (scene) by name.
	public void loadLevel(string levelName) {
		SceneManager.LoadScene(levelName);
	}

	// Load the next level based on build index.
	public void loadNextLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	// Reload the current level.
	public void reloadLevel() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}