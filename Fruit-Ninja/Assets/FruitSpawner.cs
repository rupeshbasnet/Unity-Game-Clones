using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	// Here we have a gameobject fruitprefab
	public GameObject fruitPrefab;

	// Array of transform that has our spawnpoints
	// To make it more dynamic we can later add random point position and locations 
	// but for this MVP we only have three static points
	public Transform[] spawnPoints;

	// Delay max and min for the Wairforseconds method
	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnFruits ());
	}
	
	IEnumerator SpawnFruits ()
	{
		while (true) 
		{	
			// Add delay in each of these iterations
			// The delay time could be static. however to make it interesting 
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);


			// Spawn fruits at a random spawn point
			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
			Destroy(spawnFruit, 5f);

		}
	}
}
