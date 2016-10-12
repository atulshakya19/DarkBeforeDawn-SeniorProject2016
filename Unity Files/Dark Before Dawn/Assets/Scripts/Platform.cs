using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	private Collider platformCollider;
	private Collider colliderReset;

	// Use this for initialization
	void Start () {
		platformCollider = GetComponent<BoxCollider> ();
		colliderReset = transform.FindChild ("Collider Reset").GetComponent<BoxCollider> ();
		colliderReset.enabled = false;
		platformCollider.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {

	}

	/*
	void OnTriggerEnter (Collider other){
		platformCollider.isTrigger = true;
	}
	*/

	void OnCollisionExit (Collision other){
		colliderReset.enabled = true;
	}
}
