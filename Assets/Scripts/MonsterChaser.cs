using UnityEngine;
using System.Collections;

/// <summary>
/// Setup the chase behavior of a monster game object.
/// </summary>
public class MonsterChaser : MonoBehaviour {
	
	public float speed = 10.0f;
	public float maxDist = 25f;
	public float minDist = 1f;
	public Transform target;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
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

		// As the chaser is farther away than the minimum distance, move towards it at rate speed.
		if (distance > maxDist) {
			//transform.position += transform.forward * speed * Time.deltaTime;
		} else if (distance > minDist && distance < maxDist) {
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		// It is close enough so play the attack animation.
		else {
			Animation anim = GetComponent<Animation> ();
			anim.CrossFade ("Anim_Attack");
		}
	}

	/// <summary>
	/// Set the target of the chaser.
	/// </summary>
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
