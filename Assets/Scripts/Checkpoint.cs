using UnityEngine;
using System.Collections;

// Sets the respawn location of a player when trigger
public class Checkpoint : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter(Collider collision)						// used for things like bullets, which are triggers.  
	{
		if ((collision.gameObject.tag == "Player") && (collision.gameObject.GetComponent<Health> () != null))
		{
			collision.gameObject.GetComponent<Health>().updateRespawn(collision.gameObject.transform.position, collision.gameObject.transform.rotation);
		}
	}
}
