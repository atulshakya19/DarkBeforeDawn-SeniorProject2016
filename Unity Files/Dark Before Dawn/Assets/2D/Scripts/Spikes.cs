using UnityEngine;
using System.Collections;

public class Spikes : RaycastController {

	private GameObject player;
	public int damage;

	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");

	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.CompareTag ("Player")) {
			print ("OUCH!!!");
			player.GetComponent<PlayerHealth> ().isDamaged (damage);
		}
	}
}
