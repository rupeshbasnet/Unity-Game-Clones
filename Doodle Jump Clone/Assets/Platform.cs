using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {

	public float jumpForce = 10f;

	void OnCollisionEnter2D(Collision2D col) 
	{
		// Check if the object is coming from the buttom or the top
		// using the relativeVelocity.y to get the velocity of the two components
		if (col.relativeVelocity.y <= 0f) {


			// We need to grab the rigidbody of the thing that collided with the platform
			// The collider's Get Componenet
			Rigidbody2D rb = col.collider.GetComponent<Rigidbody2D> ();				

			// However, some elements may not have rigidbody like other platforms
			if (rb != null) {
				// We need a way to add the force to the rigidbody that was collided
				// rb.AddForce ();
				// Using Addforce will make it such that the rigidbody's current velocity
				// will compete with the new add force

				// We want to set the velocity directly
				// We first store the velocity of the rigidbody in its current state
				Vector2 velocity = rb.velocity;
				// Set the y attribute of the velocity as the jumpforce
				velocity.y = jumpForce;
				// Reset the velocity with out new vector2 velocity
				rb.velocity = velocity;


			}
		}
	}
}
