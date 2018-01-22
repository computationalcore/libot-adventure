using UnityEngine;
using System.Collections;

/// <summary>
/// Setup the rotate behavior of a game object.
/// </summary>
public class Rotate : MonoBehaviour {
	
	public float speed = 10.0f;
	
	public enum whichWayToRotate {AroundX, AroundY, AroundZ}

	public whichWayToRotate way = whichWayToRotate.AroundX;

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		switch(way) {
			case whichWayToRotate.AroundX:
				transform.Rotate(Vector3.right * Time.deltaTime * speed);
				break;
			case whichWayToRotate.AroundY:
				transform.Rotate(Vector3.up * Time.deltaTime * speed);
				break;
			case whichWayToRotate.AroundZ:
				transform.Rotate(Vector3.forward * Time.deltaTime * speed);
				break;
		}	
	}
}