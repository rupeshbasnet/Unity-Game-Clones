using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	// We need to have a variable that needs to determine if we are currently
	// cutting or not
	bool isCutting = false;

	// Update is called once per frame
	void Update () {
		// We want to check for the mouse button down 0 -> for left mouse button
		if (Input.GetMouseButtonDown (0)) {
			// The button has been pressed
			StartCutting ();
			
		} else if (Input.GetMouseButtonUp (0)) {
			StopCutting ();
		}

	}

	void StartCutting () {
		isCutting = true;
	}

	void StopCutting () {
		isCutting = false;
	}


}
