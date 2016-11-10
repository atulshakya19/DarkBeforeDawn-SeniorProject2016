using UnityEngine;
using System.Collections;

public class SpawnObject : MonoBehaviour {
	public float spawnTime = 1.5f;
	public float spawnWait = 2f;
	public GameObject[] fallingObjects;

	[Header("Range X")]
	public float xMin;
	public float xMax;

	[Header("Range Y")]
	public float yMin;
	public float yMax;

	void Start(){

	}

	void Update(){
		spawnTime -= Time.deltaTime;
		if (spawnTime <= 0) {
			Spawn();
			spawnTime = spawnWait;
		}

	}

	public void Spawn(){

		Vector2 pos = new Vector2 (Random.Range(xMin,xMax), Random.Range(yMin, yMax));
		GameObject spawnObjects = fallingObjects [Random.Range (0, fallingObjects.Length)];

		Instantiate (spawnObjects, pos, transform.rotation);
	}
}
