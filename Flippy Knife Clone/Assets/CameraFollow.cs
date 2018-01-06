using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothSpeed = .3f;
	public Vector3 offset;
	void LateUpdate() 
	{
		/*if (target.position.y > transform.position.y) {
			Vector3 newPos = new Vector3 (transform.position.x, target.position.y, transform.position.z);
			transform.position = Vector3.SmoothDamp(transform.position, newPos, ref currentVelocity, smoothSpeed * Time.deltaTime);
		}*/
		transform.position = target.position + offset;
	}
}
