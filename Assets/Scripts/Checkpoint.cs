using UnityEngine;
using System.Collections;

/// <summary>
/// Setup he respawn location of a player when trigger.
/// </summary>
public class Checkpoint : MonoBehaviour {
	
	/// <summary>
	/// Called when the Collider "other" enters the trigger.
	/// Used for things like bullets, which are triggers.
	/// See https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	/// </summary>
	void OnTriggerEnter(Collider collision) {
		if ((collision.gameObject.tag == "Player") && (collision.gameObject.GetComponent<Health> () != null))
		{
			collision.gameObject.GetComponent<Health>().updateRespawn(collision.gameObject.transform.position, collision.gameObject.transform.rotation);
		}
	}
}
