using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	// We could use a level generation method of creating levels around the player
	// However its time consuming for this introduction
	// We will be loading the entire level as the player starts to play the game

	// Get the reference to the platform
	public GameObject platformPrefab;

	// Get the int of the number of platforms to spawn
	public int numberOfPlatforms = 200;

	// The width of our level
	public float levelWidth = 3f;

	public float minY = .2f;
	public float maxY = 1.5f;

	// Use this for initialization
	void Start () {

		Vector3 spawnPosition = new Vector3 ();
		// Only instantiate till we reach the desired number of platforms
		for (int i = 0; i < numberOfPlatforms; i++) 
		{
			spawnPosition.y += Random.Range (minY, maxY);
			spawnPosition.x = Random.Range (-levelWidth, levelWidth);
			// Create the prefab in the spawnPosition and use the Identity for rotation 
			// which means we wont rotate at all
			Instantiate (platformPrefab, spawnPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
