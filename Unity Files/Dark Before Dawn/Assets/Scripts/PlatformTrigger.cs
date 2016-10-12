using UnityEngine;
using System.Collections;

public class PlatformTrigger : MonoBehaviour {

	private Collider colliderTrigger;
	private Collider platformCollider;

	// Use this for initialization
	void Start () {
		colliderTrigger = GetComponent<BoxCollider> ();
		platformCollider = transform.parent.GetComponent<BoxCollider> ();
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
