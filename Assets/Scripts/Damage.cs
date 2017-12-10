using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour {
	
	public float damageAmount = 10.0f;
	
	public bool damageOnTrigger = true;
	public bool damageOnCollision = false;
	public bool continuousDamage = false;
	public float continuousTimeBetweenHits = 0;

	public bool destroySelfOnImpact = false;	// variables dealing with exploding on impact (area of effect)
	public float delayBeforeDestroy = 0.0f;
	public GameObject explosionPrefab;

	private float savedTime = 0;

	void OnTriggerEnter(Collider collision)						// used for things like bullets, which are triggers.  
	{
		if (damageOnTrigger) {
			if (this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")	// if the player got hit with it's own bullets, ignore it
				return;
		
			if (collision.gameObject.GetComponent<Health> () != null) {	// if the hit object has the Health script on it, deal damage
				collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
		
				if (destroySelfOnImpact) {
					Destroy (gameObject, delayBeforeDestroy);	  // destroy the object whenever it hits something
				}
			
				if (explosionPrefab != null) {
					Instantiate (explosionPrefab, transform.position, transform.rotation);
				}
			}
		}
	}


	void OnCollisionEnter(Collision collision) 						// this is used for things that explode on impact and are NOT triggers
	{	
		if (damageOnCollision) {
			if (this.tag == "PlayerBullet" && collision.gameObject.tag == "Player")	// if the player got hit with it's own bullets, ignore it
				return;
		
			if (collision.gameObject.GetComponent<Health> () != null) {	// if the hit object has the Health script on it, deal damage
				collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
			
				if (destroySelfOnImpact) {
					Destroy (gameObject, delayBeforeDestroy);	  // destroy the object whenever it hits something
				}
			
				if (explosionPrefab != null) {
					Instantiate (explosionPrefab, transform.position, transform.rotation);
				}
			}
		}
	}


	void OnCollisionStay(Collision collision) // this is used for damage over time things
	{
		if (continuousDamage) {
			if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<Health> () != null) {	// is only triggered if whatever it hits is the player
				if (Time.time - savedTime >= continuousTimeBetweenHits) {
					savedTime = Time.time;
					collision.gameObject.GetComponent<Health> ().ApplyDamage (damageAmount);
				}
			}
		}
	}
	
}