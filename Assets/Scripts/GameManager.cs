using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Main Game Manager.
/// </summary>
public class GameManager : MonoBehaviour {

	public static GameManager gm;

	[Tooltip("If not set, the player will default to the gameObject tagged as Player.")]
	public GameObject player;

	public enum gameStates {Playing, Death, GameOver, BeatLevel};
	public gameStates gameState = gameStates.Playing;

	public int score = 0;

	public bool canBeatLevel = false;

	[Tooltip("Mark this is current scene/level is the final one.")]
	public bool isFinalLevel = false;

	public int beatLevelScore = 0;

	public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public GameObject gameOverCanvas;
	public Text gameOverScoreDisplay;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public GameObject beatLevelCanvas;

	public AudioSource backgroundMusic;
	public AudioClip gameOverSFX;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public AudioClip beatLevelSFX;

	private Health playerHealth;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		if (gm == null) 
			gm = gameObject.GetComponent<GameManager>();

		if (player == null) {
			player = GameObject.FindWithTag("Player");
		}

		playerHealth = player.GetComponent<Health>();

		// Setup score display.
		Collect (0);

		// Make other UI inactive.
		gameOverCanvas.SetActive (false);
		if (canBeatLevel)
			beatLevelCanvas.SetActive (false);
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		switch (gameState)
		{
			case gameStates.Playing:
				if (playerHealth.isAlive == false)
				{
					// Update gameState.
					gameState = gameStates.Death;

					// Set the end game score.
					gameOverScoreDisplay.text = mainScoreDisplay.text;

					// Show Game Over Canvas.		
					mainCanvas.SetActive (false);
					gameOverCanvas.SetActive (true);

					// Set Play Again Button as selected.
					GameObject myEventSystem = GameObject.Find("EventSystem");
					myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(GameObject.Find("Play Again Button"));
				}
				else if (canBeatLevel && score>=beatLevelScore) {
					// Update gameState.
					gameState = gameStates.BeatLevel;

					// Hide the player so game doesn't continue playing.
					player.SetActive(false);

					// Show Beat Level Canvas.
					mainCanvas.SetActive (false);
					beatLevelCanvas.SetActive (true);

					GameObject myEventSystem = GameObject.Find("EventSystem");
					if (!isFinalLevel) {
						// Set Play Again Button as selected.
						myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (GameObject.Find ("Next Level Button"));
					} else {
						// Set Main Menu Button as selected.
						myEventSystem.GetComponent<UnityEngine.EventSystems.EventSystem> ().SetSelectedGameObject (GameObject.Find ("Main Menu Button"));
					}
					
				}
				break;
			case gameStates.Death:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (gameOverSFX,gameObject.transform.position);
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.BeatLevel:
				backgroundMusic.volume -= 0.01f;
				if (backgroundMusic.volume<=0.0f) {
					AudioSource.PlayClipAtPoint (beatLevelSFX,gameObject.transform.position);
					gameState = gameStates.GameOver;
				}
				break;
			case gameStates.GameOver:
				// Do nothing
				break;
		}

	}

	/// <summary>
	/// Update the score text.
	/// </summary>
	public void Collect(int amount) {
		score += amount;
		if (canBeatLevel) {
			mainScoreDisplay.text = score.ToString () + " of " + beatLevelScore.ToString ();
		} else {
			mainScoreDisplay.text = score.ToString ();
		}

	}
}
