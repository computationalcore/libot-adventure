using UnityEngine;
using System.Collections;

/// <summary>
/// Setup the enemy game object movement pattern.
/// </summary>
public class EnemyMove : MonoBehaviour {
	
	// Enemy move speed.
	public float moveSpeed = 5f;
	// All waypoints.
	public GameObject[] myWaypoints;
	// Used as index for My_Waypoints.
	private int myWaypointId = 0;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	void Start () {
		// Speed of the box is based on the game difficulty.
		if (GameSettings.difficulty == GameSettings.gameDifficulties.Easy) {
			moveSpeed = moveSpeed * 0.6f;
		} else if (GameSettings.difficulty == GameSettings.gameDifficulties.Normal) {
			moveSpeed = moveSpeed * 0.8f;
		}
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void EnemyMovement() {
		// if there isn't anything in My_Waypoints.
		if(myWaypoints.Length != 0) {
			// If the enemy is close enough to waypoint, make it's new target the next waypoint.
			if(Vector3.Distance(myWaypoints[myWaypointId].transform.position, transform.position) <= 0) {
				myWaypointId++;
			}
			
			if(myWaypointId >= myWaypoints.Length) {
				myWaypointId = 0;
			}
			
			// Move towards waypoint.
			transform.position = Vector3.MoveTowards(transform.position, myWaypoints[myWaypointId].transform.position, moveSpeed * Time.deltaTime);
		}
	}
	
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update () {
		EnemyMovement();
	}
}