using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// Handle the Level load event.
/// </summary>
public class TriggerLevelLoad : MonoBehaviour {

	public string nameOfLevelToLoad  = "";

	/// <summary>
	/// Called when the Collider "other" enters the trigger.
	/// Used for things like bullets, which are triggers.
	/// See https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html
	/// </summary>
	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player" )
		{
			SceneManager.LoadScene(nameOfLevelToLoad);
		}
	}
}
