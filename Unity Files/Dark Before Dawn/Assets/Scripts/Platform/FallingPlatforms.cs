using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour {

	private Collider platformCol;
	private Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Player") {
			rigidbody = gameObject.AddComponent<Rigidbody> ();
			rigidbody.freezeRotation = true;
		}
	}
}
