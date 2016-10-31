using UnityEngine;
using System.Collections;

public class MovementScriptB: MonoBehaviour {

	Rigidbody rigidBody;
	private GameObject player;
	private RopeScript1 _rope;

	public float speed = 100f;


	// Use this for initialization
	void Start () {
		_rope = GetComponent<RopeScript1> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (_rope._touch) {
			Debug.Log (transform.localRotation.z);
			if (transform.localRotation.z < 0) {
				transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			} else {
				transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			}
		}
		*/

		if (Input.GetKey (KeyCode.A)){
			transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
		}else if (Input.GetKey (KeyCode.D)){
			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
		}
			
	}

}
