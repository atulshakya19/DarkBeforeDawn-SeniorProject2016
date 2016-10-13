using UnityEngine;
using System.Collections;

public class ColliderReset : MonoBehaviour {

	private Collider platformCollider; //collider for the platform where the player lands

	// Use this for initialization
	void Start () {
		platformCollider = transform.parent.GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player") {
			platformCollider.isTrigger = true;
	
		}
	}
}
