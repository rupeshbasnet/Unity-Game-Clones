using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	// Here we want a method that is invoked whenever we detect something triggering and entering
	// We are using the default unity method for 2D
	void OnTriggerEnter2D (Collider2D col)
	{
		// If the tag of the 2D element that we collide to is Blade tag
		if (col.tag == "Blade") 
		{
			// Test 
			Debug.Log("We Hit a fruit");
			// Then we destroy gameobject - > fruit
			Destroy(gameObject);
		}
	}
}
