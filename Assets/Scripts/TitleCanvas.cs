using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
		RectTransform gameTitle = this.gameObject.GetComponent<RectTransform> ();
		Text m_Text = this.gameObject.GetComponent<Text>();
		print (Screen.width);
		m_Text.fontSize = (int) (0.08 * Screen.width);
		print (m_Text.fontSize);


		// Check if the device running this is a handheld and show jostick control.
		if (m_Text.fontSize < 180) {
			print("Adaptei");
			// Set the correct size and position of the button dependent of the screen size 
			//Change the RectTransform size to allow larger fonts and sentences
			gameTitle.sizeDelta = new Vector2(m_Text.fontSize, 100);

		}
	}
}
