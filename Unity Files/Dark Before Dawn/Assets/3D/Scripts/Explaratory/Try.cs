using UnityEngine;
using System.Collections;

public class Try : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().freezeRotation = true;
		if (Input.GetAxis ("Horizontal") >0 ) {
			GetComponent<Rigidbody> ().AddForce (new Vector3(10, 0, 0), ForceMode.Impulse);
		}
		else if (Input.GetKeyDown (KeyCode.D)) {
			GetComponent<Rigidbody> ().AddForce  (new Vector3(-10, 0, 0), ForceMode.Impulse);
		}
	}
}
