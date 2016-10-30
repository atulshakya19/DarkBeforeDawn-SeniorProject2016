using UnityEngine;
using System.Collections;

public class MovementScriptB: MonoBehaviour {

	Rigidbody rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)){
			transform.Translate (new Vector3 (-1, 0, 0) * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.D)){
			transform.Translate (new Vector3 (1, 0, 0) * Time.deltaTime);
		}
			
	}

}
