using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour {

	// Reference our blade trail prefab
	public GameObject bladeTrailPrefab;

	// We need to have a variable that needs to determine if we are currently
	// cutting or not
	bool isCutting = false;

	GameObject currentBladeTrail;

	// Getting the reference to our rigidBody
	Rigidbody2D rb;
	Camera cam;

	void Start () {
		cam = Camera.main;
		rb = GetComponent<Rigidbody2D> ();	
	}


	// Update is called once per frame
	void Update () {
		// We want to check for the mouse button down 0 -> for left mouse button
		if (Input.GetMouseButtonDown (0)) {
			// The button has been pressed
			StartCutting ();
			
		} else if (Input.GetMouseButtonUp (0)) {
			StopCutting ();
		}

		// We need to update the position of our blade to follow our mouse around
		// whenever we are actually cutting
		if (isCutting) {
			UpdateCut ();
		}

	}

	void UpdateCut () {
		// We want to update the position of our rigidbody which is our blade
		// Input.mousePosition is the currently screen co-ordinates of our
		// mouse value. Which is very large. We want to convert this in to 
		// world co-ordinates, but inorder to convert to the world co-ordinates
		// we need a reference to our cam which will be in the start method
		// rb.position = Input.mousePosition;
		rb.position = cam.ScreenToWorldPoint(Input.mousePosition);


	}

	void StartCutting () {

		isCutting = true;

		// Everytime we are cutting we wnat to instanciate the bladetrail prefab
		// However with instantiate we need to supply the cordinates of the parent
		// game object transform (the location to instantiate the blade trail)
		// Instantiate(bladeTrailPrefab, transform);
		// But this will create our instant as a child object
		// We should unparent it after we instantiate ASAP. therefore we create a reference 
		// of this instantiated gameobject - > on StopCutting call
		// We set the parent of this gameobject to null thus deparenting it

		// *** We are parenting the currentBladeTrail b/c we want to trail to be at 
		// mouse position when it is instantiated ***
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);

	}

	void StopCutting () {
		isCutting = false;
		// This will deparent immediately
		currentBladeTrail.transform.SetParent (null);
		Destroy (currentBladeTrail, 2F);
	}


}
