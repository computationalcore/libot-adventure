using UnityEngine;
using System.Collections;

/// <summary>
/// A timer used to destroy a game object after a period.
/// </summary>
public class TimedObjectDestructor : MonoBehaviour {

	// Time (in seconds) to destroy 
	public float timeOut = 1.0f;
	// Detach the children before destroying if true.
	public bool detachChildren = false;

	/// <summary>
	/// Called when the script instance is being loaded.
	/// See https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
	/// </summary>
	void Awake () {
		// Invoke the DestroyNow funtion to run after timeOut seconds.
		Invoke ("DestroyNow", timeOut);
	}

	/// <summary>
	/// Destroys the game object this script instance is attached to.
	/// </summary>
	void DestroyNow () {
		if (detachChildren) { 
			// Detach the children before destroying if specified.
			transform.DetachChildren ();
		}
		Destroy(gameObject);
	}
}
