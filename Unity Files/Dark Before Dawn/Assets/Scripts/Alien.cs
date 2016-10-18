using UnityEngine;
using System.Collections;

public class Alien : MonoBehaviour {

	public int attackValue;
	public int health;
	public float speed = 0.10f;

	public static int numAlien;
	public bool die;
	public GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		numAlien++;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (player.transform.position - transform.position).normalized;
		float distance = (player.transform.position - transform.position).magnitude;
		Vector3 move = transform.position + (direction * speed);
		transform.position = move;
		if (distance < 1f) {
			die = true;
		}
		if (die) {
			numAlien--;
			Destroy (gameObject);
		}
	}
}
