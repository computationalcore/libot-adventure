using UnityEngine;
using System.Collections;

/// <summary>
/// A generic game object spawner class.
/// </summary>
public class SpawnGameObjects : MonoBehaviour {

	// The prefab of the game object to spawn.
	public GameObject spawnPrefab;

	// The spawn time internal. The object is spawned randomly under this interval.
	public float minSecondsBetweenSpawning = 3.0f;
	public float maxSecondsBetweenSpawning = 6.0f;

	// Set this if the spawners should chase another game object.
	public Transform chaseTarget;

	private float savedTime;
	private float secondsBetweenSpawning;

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
		savedTime = Time.time;
		secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
	}

	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update () {
		// Check if it is the time to spawn again.
		if (Time.time - savedTime >= secondsBetweenSpawning) 
		{
			MakeThingToSpawn();
			savedTime = Time.time; // store for next spawn
			secondsBetweenSpawning = Random.Range (minSecondsBetweenSpawning, maxSecondsBetweenSpawning);
		}	
	}

	/// <summary>
	/// Create and setup the spawned game object.
	/// </summary>
	void MakeThingToSpawn() {
		// Create a new gameObject
		GameObject clone = Instantiate(spawnPrefab, transform.position, transform.rotation) as GameObject;

		// Set chaseTarget if specified
		if ((chaseTarget != null) && (clone.gameObject.GetComponent<Chaser> () != null))
		{
			clone.gameObject.GetComponent<Chaser>().SetTarget(chaseTarget);
		}
	}
}