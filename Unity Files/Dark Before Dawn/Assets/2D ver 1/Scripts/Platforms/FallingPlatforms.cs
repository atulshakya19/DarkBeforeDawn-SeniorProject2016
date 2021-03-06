﻿using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour {

	private Collider platformCol;
	private Rigidbody2D rb2d;

	//How long should the bullet live
	public float platformTime =5f;

	// Has the spawning started
	private bool _started;

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Player") {
			if (!_started)
			{
				StartCoroutine(TimeToDie());
			}


			rb2d.freezeRotation = true;
		}
	}

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(platformTime);

		//Destry the target
		rb2d = gameObject.AddComponent<Rigidbody2D> ();
	}

}
