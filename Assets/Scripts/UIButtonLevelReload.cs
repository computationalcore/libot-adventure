using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIButtonLevelReload : MonoBehaviour {

	public void reloadLevel() {
		// Reload the current level
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
