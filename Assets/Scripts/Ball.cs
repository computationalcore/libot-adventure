using UnityEngine;
using System;

/// <summary>
/// The Ball player class.
/// </summary>
public class Ball : MonoBehaviour {
	// The force added to the ball to move it.
	[SerializeField] private float m_MovePower = 5;

	// Whether or not to use torque to move the ball.
	[SerializeField] private bool m_UseTorque = true;

	// The maximum velocity the ball can rotate at.
	[SerializeField] private float m_MaxAngularVelocity = 25;

	// The force added to the ball when it jumps.
	[SerializeField] private float m_JumpPower = 2;

	// The length of the ray to check if the ball is grounded.
	private const float k_GroundRayLength = 1f;
	private Rigidbody m_Rigidbody;

	/// <summary>
	/// Use this for initialization.
	/// </summary>
	private void Start() {
		m_Rigidbody = GetComponent<Rigidbody>();
		// Set the maximum angular velocity.
		GetComponent<Rigidbody>().maxAngularVelocity = m_MaxAngularVelocity;
	}

	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	public void Move(Vector3 moveDirection, bool jump) {
		// If using torque to rotate the ball
		if (m_UseTorque)
		{
			// Add torque around the axis defined by the move direction.
			m_Rigidbody.AddTorque(new Vector3(moveDirection.z, 0, -moveDirection.x)*m_MovePower);
		}
		else
		{
			// Otherwise add force in the move direction.
			m_Rigidbody.AddForce(moveDirection*m_MovePower);
		}

		// If on the ground and jump is pressed
		if (Physics.Raycast(transform.position, -Vector3.up, k_GroundRayLength) && jump)
		{
			// Add force in upwards.
			m_Rigidbody.AddForce(Vector3.up*m_JumpPower, ForceMode.Impulse);
		}
	}
}
