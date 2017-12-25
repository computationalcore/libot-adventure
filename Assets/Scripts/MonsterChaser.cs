using UnityEngine;
using System.Collections;

//[RequireComponent(typeof(CharacterController))]

public class MonsterChaser : MonoBehaviour {
	
	public float speed = 10.0f;
	public float maxDist = 25f;
	public float minDist = 1f;
	public Transform target;

	// Use this for initialization
	void Start () 
	{
		// if no target specified, assume the player
		if (target == null) {

			if (GameObject.FindWithTag ("Player")!=null)
			{
				target = GameObject.FindWithTag ("Player").GetComponent<Transform>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (target == null)
			return;

		// face the target
		transform.LookAt(target);

		//get the distance between the chaser and the target
		float distance = Vector3.Distance(transform.position,target.position);

		//so long as the chaser is farther away than the minimum distance, move towards it at rate speed.
		if (distance > maxDist) {
			//transform.position += transform.forward * speed * Time.deltaTime;
		} else if (distance > minDist && distance < maxDist) {
			transform.position += transform.forward * speed * Time.deltaTime;
		}
		else {
			Animation anim = GetComponent<Animation> ();
			anim.CrossFade ("Anim_Attack");

		}
	}

	// Set the target of the chaser
	public void SetTarget(Transform newTarget)
	{
		target = newTarget;
	}

}
