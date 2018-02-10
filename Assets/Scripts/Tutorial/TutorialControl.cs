using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

/// <summary>
/// A class that deals with Load Level events.
/// </summary>
public class TutorialControl : MonoBehaviour {

	public GameObject coin;
	public GameObject crate;
	public GameObject stoneMonster;
	public GameObject tutorialCanvas;
	public GameObject tutorialGameElements;
	public GameObject menuCanvas;
	public GameObject nextButton;
	public GameObject backButton;
	public Text elementTitle;
	public Text elementDescription;

	private Transform target;

	private int targetIndex = 0;

	private GameObject tutorialLight;

	private GameObject[] availableTargets;
	private string[] availableTargetsTitle;
	private string[] availableTargetsDescription;

	// starting value for the Lerp
	private float t = 0.0f;
	private float timeToMove = 1.0f;


	void Start() {
		availableTargets = new GameObject[] { coin, crate, stoneMonster };
		availableTargetsTitle = new string[] { "Coin", "Mystic Crate", "Stone Monster" };
		availableTargetsDescription = new string[] { "To complete the level you must collect a certain number of coins indicated when each level starts", "The mystic crate the spawned frequently by the game, it chases the LiBot", "This monster pass throght any solid, including rocks and the ground. It chases the player when it is in contact view" };
	}

	/// <summary>
	/// Called every frame, if the Behaviour is enabled. 
	/// LateUpdate is called after all Update functions have been called.
	/// See https://docs.unity3d.com/ScriptReference/MonoBehaviour.LateUpdate.html
	/// </summary>
	void LateUpdate() {

		// Early out if we don't have a target
		if (!target || (transform.position.x == target.position.x))
			return;

		// Linearly interpolates between current camera x position and the target x position by t.
		transform.position = new Vector3(Mathf.Lerp(transform.position.x, target.position.x, t), transform.position.y, transform.position.z);

		// now check if the interpolator has reached 1.0
		// and swap maximum and minimum so game object moves
		// in the opposite direction.
		if (t < 1.0f) {
			// .. increate the t interpolater
			t += Time.deltaTime / timeToMove;
		} else {
			t = 1.0f;
		}

		print ("cam: " + transform.position.x);
		print ("object " + target.position.x);
		print ("----------------------------");
	}

	/// <summary>
	/// Load a level (scene) by name..
	/// </summary>
	public void goToNext() {
		if (targetIndex == availableTargets.Length - 1 )
			return;
		targetIndex += 1;
		SetTarget (targetIndex);

	}

	public void goBack() {
		if (targetIndex == 0)
			return;
		targetIndex -= 1;
		SetTarget (targetIndex);
	}

	private void SetTarget(int targetIndex) {
		if (targetIndex == 0) {
			backButton.SetActive (false);
		} else if (targetIndex == availableTargets.Length - 1) {
			nextButton.SetActive (false);
		} else {
			backButton.SetActive (true);
			nextButton.SetActive (true);
		}

		target = availableTargets [targetIndex].transform;
		elementTitle.text = availableTargetsTitle [targetIndex];
		elementDescription.text = availableTargetsDescription [targetIndex];
		// resets the lerp interpolater.
		t = 0.0f;
	}

	public IEnumerator MoveToPosition(Transform transform, Vector3 position, float timeToMove)
	{
		var currentPos = transform.position;
		var t = 0f;
		while(t < 1)
		{
			t += Time.deltaTime / timeToMove;
			transform.position = Vector3.Lerp(currentPos, position, t);
			yield return null;
		}
	}
}