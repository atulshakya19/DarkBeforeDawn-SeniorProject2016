using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

	private Collider colliderTrigger; //trigger that makes the platformCollider none triggered
	private Collider platformCollider; //collider for the platform where the player lands

	// Use this for initialization
	void Start () {
		//colliderTrigger = GetComponent<BoxCollider2D> ();
		//platformCollider = transform.parent.GetComponent<BoxCollider2D> ();

		colliderTrigger.isTrigger = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter (Collider coll){
		platformCollider.isTrigger = false;
	}

	void OnTriggerExit (Collider coll){
		platformCollider.isTrigger = false;
	}
}
