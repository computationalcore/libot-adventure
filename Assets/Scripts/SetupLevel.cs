using UnityEngine;
using System.Collections;

/// <summary>
/// Setup enemy spawners and monsters of a level/scene based on difficulty.
/// </summary>
public class SetupLevel : MonoBehaviour {

	// The prefab of the game object to spawn.
	public GameObject enemySpawnerPrefab;

	public GameObject coinSpawnerPrefab;

	public string levelName = "Level1";

	private float averageDistanceBetweenPrefabs;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		if (levelName == "Level1") {
			averageDistanceBetweenPrefabs = 10;
			// The spawn time internal of elements is based on game difficulty.
			switch (GameSettings.difficulty) {
			case GameSettings.gameDifficulties.Hard:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {
						// Create and set up a new EnemySpawner game object.
						GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
						clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 5.0f;
						clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 10.0f;
					}
				}
				break;
			case GameSettings.gameDifficulties.Normal:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {

						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 1.5) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 5.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 5.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 10.0f;
						}
					}
				}
				break;
				// Easy is the default
			default:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 2.0) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 3.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 15.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 20.0f;
						}
					}
				}
				break;
			}
		}
		else if (levelName == "Level2") {
			averageDistanceBetweenPrefabs = 14;
			// The spawn time internal of elements is based on game difficulty.
			switch (GameSettings.difficulty) {
			case GameSettings.gameDifficulties.Hard:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {
						// Create and set up a new EnemySpawner game object.
						GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
						clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 5.0f;
						clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 10.0f;
					}
				}
				break;
			case GameSettings.gameDifficulties.Normal:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {

						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 1.5) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 5.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 10.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 15.0f;
						}
					}
				}
				break;
				// Easy is the default
			default:
				for (int i = -1; i <= 1; i++) {
					for (int j = -1; j <= 1; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 2.0) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 3.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 15, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 15.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 20.0f;
						}
					}
				}
				break;
			}
		}
		else if (levelName == "Level3") {
			averageDistanceBetweenPrefabs = 25;
			// The spawn time internal of elements is based on game difficulty.
			switch (GameSettings.difficulty) {
			case GameSettings.gameDifficulties.Hard:
				for (int i = -2; i <= 2; i++) {
					for (int j = -2; j <= 2; j++) {
						// Create and set up a new EnemySpawner game object.
						GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
						clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 5.0f;
						clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 10.0f;
					}
				}
				break;
			case GameSettings.gameDifficulties.Normal:
				for (int i = -2; i <= 2; i++) {
					for (int j = -2; j <= 2; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 1.5) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 5.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 10.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 15.0f;
						}
					}
				}
				break;
				// Easy is the default
			default:
				for (int i = -2; i <= 2; i++) {
					for (int j = -2; j <= 2; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 2.0) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 3.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 15.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 20.0f;
						}
					}
				}
				break;
			}
		} else if (levelName == "Level4") {
			averageDistanceBetweenPrefabs = 20;
			// The spawn time internal of elements is based on game difficulty.
			switch (GameSettings.difficulty) {
			case GameSettings.gameDifficulties.Hard:
				for (int i = -3; i <= 3; i++) {
					for (int j = -3; j <= 3; j++) {
						// Create and set up a new EnemySpawner game object.
						GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
						clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 5.0f;
						clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 10.0f;
					}
				}
				break;
			case GameSettings.gameDifficulties.Normal:
				for (int i = -3; i <= 3; i++) {
					for (int j = -3; j <= 3; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 1.5) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 5.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 10.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 15.0f;
						}
					}
				}
				break;
				// Easy is the default
			default:
				for (int i = -3; i <= 3; i++) {
					for (int j = -3; j <= 3; j++) {
						// Returns a random float number between and min [inclusive] and max [inclusive].
						float random = Random.Range (0.0f, 3.0f);
						if (random <= 2.0) {
							// Create a new CoinSpawner game object.
							GameObject clone = Instantiate (coinSpawnerPrefab, new Vector3 (i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 1.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 3.0f;
						} else {
							// Create a new EnemySpawner game object.
							GameObject clone = Instantiate (enemySpawnerPrefab, new Vector3(i * averageDistanceBetweenPrefabs, 30, j * averageDistanceBetweenPrefabs), Quaternion.identity) as GameObject;
							clone.gameObject.GetComponent<SpawnGameObjects>().minSecondsBetweenSpawning = 15.0f;
							clone.gameObject.GetComponent<SpawnGameObjects>().maxSecondsBetweenSpawning = 20.0f;
						}
					}
				}
				break;
			}
		}
	}
}
