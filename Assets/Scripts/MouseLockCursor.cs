using UnityEngine;
using System.Collections;

public class MouseLockCursor : MonoBehaviour {

	public bool isCursorLock = true;

	// Use this for initialization
	void Start () {
		LockCursor (isCursorLock);
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetButtonDown("Cancel")){
			LockCursor (false);
		}
		if(Input.GetButtonDown("Fire1")){
			LockCursor (true);
		}
	}

	private void LockCursor(bool isLocked)
	{
		if (isLocked) 
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;
		} else {
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}
}
