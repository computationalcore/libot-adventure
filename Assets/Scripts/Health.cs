using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A game object health handler.
/// </summary>
public class Health : MonoBehaviour {
	
	public enum deathAction {loadLevelWhenDead,doNothingWhenDead};
	
	public float healthPoints = 1f;
	// Base health points.
	public float respawnHealthPoints = 1f;		

	// Lives and variables for respawning.
	public int numberOfLives = 1;
	public bool isAlive = true;	

	public GameObject explosionPrefab;
	
	public deathAction onLivesGone = deathAction.doNothingWhenDead;
	
	public string LevelToLoad = "";
	
	private Vector3 respawnPosition;
	private Quaternion respawnRotation;
	

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		// store initial position as respawn location
		respawnPosition = transform.position;
		respawnRotation = transform.rotation;

		// default to current scene
		if (LevelToLoad=="")
		{
			LevelToLoad = SceneManager.GetActiveScene().name;
		}
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		// If the object is 'dead'.
		if (healthPoints <= 0) {
			// Decrement # of lives, update lives GUI.
			numberOfLives--;
			
			if (explosionPrefab!=null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}

			// Respawn.
			if (numberOfLives > 0) { 
				// Reset the player to respawn position.
				transform.position = respawnPosition;
				transform.rotation = respawnRotation;
				// Give the player full health again.
				healthPoints = respawnHealthPoints;
			}
			// ALL lives are gone.
			else { 
				isAlive = false;
				
				switch(onLivesGone)
				{
				case deathAction.loadLevelWhenDead:
					SceneManager.LoadScene(LevelToLoad);
					break;
				case deathAction.doNothingWhenDead:
					// do nothing, death must be handled in another way elsewhere
					break;
				}
				Destroy(gameObject);
			}
		}
	}

	/// <summary>
	/// Apply damage to the health points.
	/// </summary>
	public void ApplyDamage(float amount) {	
		healthPoints = healthPoints - amount;	
	}

	/// <summary>
	/// Apply heal to the health points.
	/// </summary>
	public void ApplyHeal(float amount) {
		healthPoints = healthPoints + amount;
	}

	/// <summary>
	/// Add an extra life to the game object that this script instance is attached.
	/// </summary>
	public void ApplyBonusLife(int amount) {
		numberOfLives = numberOfLives + amount;
	}

	/// <summary>
	/// Update respawn.
	/// </summary>
	public void updateRespawn(Vector3 newRespawnPosition, Quaternion newRespawnRotation) {
		respawnPosition = newRespawnPosition;
		respawnRotation = newRespawnRotation;
	}
}
