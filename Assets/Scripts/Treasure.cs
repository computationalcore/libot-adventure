using UnityEngine;
using System.Collections;

/// <summary>
/// A treasure/icon controller.
/// </summary>
public class Treasure : MonoBehaviour {

	// Set how much the coin worth it
	public int value = 10;
	// The game object to render when the treasure is dead
	public GameObject explosionPrefab;

	/// <summary>
	/// Called when the Collider "other" enters the trigger.
	/// See: https://docs.unity3d.com/ScriptReference/MonoBehaviour.OnTriggerEnter.html
	/// </summary>
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == "Player") {
			if (GameManager.gm!=null)
			{
				// tell the game manager to Collect
				GameManager.gm.Collect (value);
			}
			
			// explode if specified
			if (explosionPrefab != null) {
				Instantiate (explosionPrefab, transform.position, Quaternion.identity);
			}
			
			// destroy after collection
			Destroy (gameObject);
		}
	}
}
