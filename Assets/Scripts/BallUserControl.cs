using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

/// <summary>
/// Setup user control for the ball player.
/// </summary>
public class BallUserControl : MonoBehaviour {
	// Virtual jostick (mobile).
	public Joystick joystick;

	// Reference to the ball controller.
	private Ball ball;

	// the world-relative desired move direction, calculated from the camForward and user input.
	private Vector3 move;

	// A reference to the main camera in the scenes transform.
	private Transform cam;

	// The current forward direction of the camera.
	private Vector3 camForward;

	// Whether the jump button is currently pressed.
	private bool jump;

	/// <summary>
	/// Called when the script instance is being loaded.
	/// See https://docs.unity3d.com/ScriptReference/MonoBehaviour.Awake.html
	/// </summary>
	private void Awake() {
		// Set up the reference.
		ball = GetComponent<Ball>();


		// Get the transform of the main camera.
		if (Camera.main != null)
		{
			cam = Camera.main.transform;
		}
		else
		{
			// Use world-relative controls in this case, which may not be what the user wants, but so warned them.
			Debug.LogWarning(
				"Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
		}
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	private void Update() {
		// Get the axis and jump input.
		float h = CrossPlatformInputManager.GetAxis("Horizontal");
		float v = CrossPlatformInputManager.GetAxis("Vertical");
		jump = CrossPlatformInputManager.GetButton("Jump");

		h = (h == 0) ? joystick.Horizontal : h;
		v = (v == 0) ? joystick.Vertical : v;

		// Calculate move direction.
		if (cam != null)
		{
			// Calculate camera relative direction to move.
			camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
			move = (v*camForward + h*cam.right).normalized;
		}
		else
		{
			// Use world-relative directions in the case of no main camera.
			move = (v*Vector3.forward + h*Vector3.right).normalized;
		}
	}

	/// <summary>
	/// Called every fixed framerate frame, if the MonoBehaviour is enabled.
	/// See https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
	/// </summary>
	private void FixedUpdate() {
		// Call the Move function of the ball controller.
		ball.Move(move, jump);
		jump = false;
	}
}