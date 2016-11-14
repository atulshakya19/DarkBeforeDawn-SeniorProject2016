using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {
	public float destroyDelay = 1.0f;
	private FallingObject fallScript;


	// Use this for initialization
	void Start () {
		fallScript = GameObject.FindObjectOfType<FallingObject> ();
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other){
		if (other.transform.tag == "Ground" || other.transform.tag == "Player") {
			Destroy (gameObject, destroyDelay);
		}
	}
	
}

