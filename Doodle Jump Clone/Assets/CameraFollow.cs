using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// The traget that the camera will follow
	public Transform target;
	public float smoothSpeed = .3f;
	// Update is called once per frame
	// We want to move the cam behind the player so we use LateUpdate which is 
	// called after the other updates
	private Vector3 currentVelocity;
	void LateUpdate () {
		// If the target's Y value is greater than our y - value then you want to 
		// move the camera basically only move with positionve y
		if (target.position.y > transform.position.y) 
		{
			Vector3 newPos = new Vector3 (transform.position.x, 
				target.position.y, transform.position.z);
			// Reset the cam's transform position with the y value of the target
			transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);
		}

	}
}
