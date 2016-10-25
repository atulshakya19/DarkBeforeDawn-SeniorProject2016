using UnityEngine;
using System.Collections;

public class MovementScriptB: MonoBehaviour {

	Rigidbody2D rigidBody;


	// Use this for initialization
	void Start () {
		rigidBody = transform.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.A)){
			rigidBody.AddForce(-Vector2.right*10);
		}

		if (Input.GetKey (KeyCode.D)){
			rigidBody.AddForce(Vector2.right*10);
		}
			
	}

}
