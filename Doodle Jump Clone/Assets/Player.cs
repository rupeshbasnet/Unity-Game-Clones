using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Make sure that we always have a rigidbody2d
[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour {

	public float movementSpeed = 10f;

	float movement = 0f;

	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		movement = Input.GetAxis ("Horizontal");
	}

	// Changing the rigidbody's movement inside of fixed update insteada
	void FixedUpdate () 
	{
		// Get the velocity vector2 of our rigidibody
		Vector2 velocity = rb.velocity;
		// Change the velocity's x attr to the movement that we got from the update method
		velocity.x = movement * movementSpeed;
		// Setting back the rigidbody's velocity
		rb.velocity = velocity;
	}
}
