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

	[Tooltip("The score necessary to beat the level in each difficulty.")]
	public int beatEasyLevelScore = 0;
	public int beatNormalLevelScore = 0;
	public int beatHardLevelScore = 0;

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

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public GameObject introBeatLevelCanvas;

	[Tooltip("Only need to set if canBeatLevel is set to true.")]
	public Text introBeatLevelText;

	private float introBeatLevelTextDuration = 2.0f;
	private float introSavedTime;

	private Health playerHealth;

	// The beat score level
	private int beatLevelScore = 0;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		Debug.Log("Start run!");
		if (gm == null) 
			gm = gameObject.GetComponent<GameManager>();

		if (player == null) {
			player = GameObject.FindWithTag("Player");
		}

		playerHealth = player.GetComponent<Health>();

		// Make other UI inactive.
		gameOverCanvas.SetActive (false);
		if (canBeatLevel) {
			// Set beat level score based on game difficulty.
			switch (GameSettings.difficulty) {
				case GameSettings.gameDifficulties.Hard:
					GameObject.FindGameObjectWithTag ("EasyModeCanvas").SetActive (false);
					GameObject.FindGameObjectWithTag ("NormalModeCanvas").SetActive (false);
					GameObject.FindGameObjectWithTag ("HardModeCanvas").SetActive (true);
					beatLevelScore = beatHardLevelScore;
					break;
				case GameSettings.gameDifficulties.Normal:
					GameObject.FindGameObjectWithTag ("EasyModeCanvas").SetActive (false);
					GameObject.FindGameObjectWithTag ("NormalModeCanvas").SetActive (true);
					GameObject.FindGameObjectWithTag ("HardModeCanvas").SetActive (false);
					beatLevelScore = beatNormalLevelScore;
					break;
				// Easy is the default
				default:
					GameObject.FindGameObjectWithTag ("EasyModeCanvas").SetActive (true);
					GameObject.FindGameObjectWithTag ("NormalModeCanvas").SetActive (false);
					GameObject.FindGameObjectWithTag ("HardModeCanvas").SetActive (false);
					beatLevelScore = beatEasyLevelScore;
					break;
			}

			beatLevelCanvas.SetActive (false);
			// Show intro level goal message (Only at first level load, doesnt show after a gameover)
			if (GameSettings.showIntroLevelMessage) {
				introBeatLevelText.text = "GET " + beatLevelScore.ToString () + " COINS\nTO BEAT THE LEVEL!";
				GameSettings.showIntroLevelMessage = false;
				StartCoroutine (ShowIntroBeatLevelCanvas ());
			}
		}

		// Setup score display.
		Collect (0);
			
	}

	/// <summary>
	/// Show intro level message with information about the coins that needs to be collected by the user to beat the level.
	/// </summary>
	public IEnumerator ShowIntroBeatLevelCanvas() {
		// Show intro beat message canvas canvas
		introBeatLevelCanvas.SetActive (true);
		// Hide main canvas
		mainCanvas.SetActive (false);
		Time.timeScale = 0.000001f;
		yield return new WaitForSeconds (introBeatLevelTextDuration * Time.timeScale);
		Time.timeScale = 1;
		// Hide intro beat message canvas canvas
		introBeatLevelCanvas.SetActive (false);
		// Show main canvas
		mainCanvas.SetActive (true);
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		switch (gameState)
		{
			case gameStates.Playing:
				if (playerHealth.isAlive == false) {
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
					// If pass on current level should show set to true to show the intro message on the next level.
					GameSettings.showIntroLevelMessage = true;
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
