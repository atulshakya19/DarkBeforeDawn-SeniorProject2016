using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {
	public Transform[] spawnPoint;
	public float spawnTime = 1.5f;

	public GameObject[] fallingObjects;

	void Start(){
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Update(){


	}

	void Spawn(){
		int spawnIndex = Random.Range (spawnPoint.Length, 0);
		//Instantiate (fallingObjects, spawnPoint [spawnIndex].position, spawnPoint [spawnIndex].rotation);
	}
}
