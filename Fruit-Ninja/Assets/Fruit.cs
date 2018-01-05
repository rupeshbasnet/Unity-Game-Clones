using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

	// In order to have a slicing effect we will be simply creating a gameobject and
	// instantiating the slice with some physics
	public GameObject fruitSlicedPrefab;

	public float startForce = 15f;

	// Creating a way to shoot the fruits upwards
	Rigidbody2D rb;

	void Start ()
	{
		// On Instantiation of the the game object get the reference of the rigidbody and
		// addforce to the rigidbody

		rb = GetComponent<Rigidbody2D>();

		// The addforce needs the direction and the force float. 
		// The mode of the force is impluse. Since we are only adding it once as an impluse

		rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
	
	}
	// Here we want a method that is invoked whenever we detect something triggering and entering
	// We are using the default unity method for 2D
	void OnTriggerEnter2D (Collider2D col)
	{
		// If the tag of the 2D element that we collide to is Blade tag
		if (col.tag == "Blade") 
		{
			// before we destroy the gameobject we will be instantiating the sliced prefab
			// Also instantiate at the current position and rotation of the unsliced water melon

			// Rotation of the sliced fruit
			// The collider col is the current position of our mouse. We can get the direction 
			// of our slice from the col and rotate the slided fruit w.r.t. to the direction of the cut.

			Vector3 direction = (col.transform.position - transform.position).normalized;

			Quaternion rotation = Quaternion.LookRotation (direction);

			// Get the ref of the instantiated game object

			GameObject slicedFruit =  Instantiate(fruitSlicedPrefab, transform.position, rotation);

			// Then we destroy gameobject - > fruit
			Destroy(slicedFruit, 3f);
		}
	}
}
