﻿using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {
	public float destroyDelay = 0.5f;
	public int damage = 1;

	private FallingObject fallScript;
	private PlayerHealth playerFruit;


	// Use this for initialization
	void Start () {
		fallScript = GameObject.FindObjectOfType<FallingObject> ();
		playerFruit = GameObject.FindObjectOfType<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other){
		if (other.transform.tag == "Ground" ||  other.transform.tag == "Through" || other.transform.tag == "Swinging Platform") {
			Destroy (gameObject);
		}

		if (other.transform.tag == "Player") {
			Destroy (gameObject);
			playerFruit.isDamaged (damage);
		}
	}
	
}

