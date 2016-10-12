using UnityEngine;
using System.Collections;

public class ColliderReset : MonoBehaviour {

	private Collider platformCollider;
	// Use this for initialization
	void Start () {
		platformCollider = transform.parent.GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerExit (Collider col){
		platformCollider.isTrigger = true;
	}
}
