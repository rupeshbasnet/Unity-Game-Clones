using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour {

	// Get the ref to our rigidbody
	public Rigidbody rb;

	private Vector2 startSwipe;

	private Vector2 endSwipe;

	public float torque = 20f;

	public float force = 5f;
	// Use this for initialization
	void Start () {
		// Check whether or not we pressed the mouse button
		// If we do, where we pressed the mouse button
		// when we release the mouse button and where we do that
		// By subtracting the two positions we wil get the vector 
		// which is the arrow pointing from the start of the mouse button to the end of the mouse button
		// This arrow is the direction we want to use and the length of the arrow is the speed	
		Physics.gravity = new Vector3(0, -3.5F, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) 
		{
			startSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		}
		if (Input.GetMouseButtonUp (0)) 
		{
			endSwipe = Camera.main.ScreenToViewportPoint(Input.mousePosition);
			// Also as soon as we release the mouse button we call the swipe function
			Swipe();
		}
	}

	void Swipe() 
	{

		rb.isKinematic = false;

		Vector2 swipe = endSwipe - startSwipe;

		// This will add the force in our knife and you can check to see that it moves with swipe

		rb.AddForce (swipe * force, ForceMode.Impulse);

		// However we want our knife to rotate every time we swipe
		rb.AddTorque(0f, 0f, -torque, ForceMode.Impulse);

	}

	void OnTriggerEnter()
	{
		// We set the rigidbody's is kinematic to truw which will freeze the rotation
		// A kinematic rb won't move unless its told to move
		rb.isKinematic = true;

		// But this will make the knife unmoveable after it is set to iskinematic true 
		// So therefore we will be setting the iskinematic to false again on another swipe
	}
}
