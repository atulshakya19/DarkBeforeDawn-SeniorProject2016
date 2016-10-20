using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public Transform b;
	private bool yes = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (yes) {
			transform.rotation = Quaternion.Lerp (transform.rotation, b.rotation, Time.deltaTime);
		}
	}

	void OnTriggerEnter (Collider col){

		if (col.transform.tag == "Player") {
			yes = true;

		}
	}
}
