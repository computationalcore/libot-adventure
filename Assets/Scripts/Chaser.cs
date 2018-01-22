using UnityEngine;
using System.Collections;

/// <summary>
/// Setup the chase behavior of a general enemy game object.
/// </summary>
public class Chaser : MonoBehaviour {
	
	public float speed = 20.0f;
	public float minDist = 1f;
	public Transform target;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start ()  {
		// If no target specified, assume the player.
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		if (target == null)
			return;

		// Face the target.
		transform.LookAt(target);

		// Get the distance between the chaser and the target.
		float distance = Vector3.Distance(transform.position,target.position);

		// So long as the chaser is farther away than the minimum distance, move towards it at rate speed.
		if(distance > minDist)	
			transform.position += transform.forward * speed * Time.deltaTime;	
	}

	/// <summary>
	/// Set the target of the chaser.
	/// </summary>
	public void SetTarget(Transform newTarget) {
		target = newTarget;
	}

}
