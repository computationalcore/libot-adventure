using System;
using UnityEngine;

/// <summary>
/// Water movement effect handler.
/// </summary>
public class WaterBasic : MonoBehaviour
{
	/// <summary>
	/// Update is called once per frame.
	/// </summary>
	void Update()
	{
		// Get the renderer component from the gameObject this script instance is attached to. Do nothing if it doesnt have any renderer.
		Renderer renderer = GetComponent<Renderer>();
		if (!renderer)
		{
			return;
		}
		// Get the shared material of the renderer, do nothing if it is None.
		Material sharedMaterial = renderer.sharedMaterial;
		if (!sharedMaterial)
		{
			return;
		}

		// Calculate and update the wave speed and scale.
		Vector4 waveSpeed = sharedMaterial.GetVector("WaveSpeed");
		float waveScale = sharedMaterial.GetFloat("_WaveScale");
		float t = Time.time / 20.0f;
		Vector4 offset4 = waveSpeed * (t * waveScale);
		Vector4 offsetClamped = new Vector4(Mathf.Repeat(offset4.x, 1.0f), Mathf.Repeat(offset4.y, 1.0f),
			Mathf.Repeat(offset4.z, 1.0f), Mathf.Repeat(offset4.w, 1.0f));
		sharedMaterial.SetVector("_WaveOffset", offsetClamped);
	}
}