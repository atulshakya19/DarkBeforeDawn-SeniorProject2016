using UnityEngine;
using System.Collections;

public class FallingObject : MonoBehaviour {

	private GameObject platform;
	public bool destroyFall = false;

	// Use this for initialization
	void Start () {
		platform = transform.FindChild ("Object1").gameObject;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Player") {
			platform.AddComponent<Rigidbody2D> ();
			destroyFall = true;
		}
	}
}
