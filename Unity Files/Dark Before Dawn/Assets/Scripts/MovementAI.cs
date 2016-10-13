using UnityEngine;
using System.Collections;

public class MovementAI : MonoBehaviour {

	private Rigidbody rigidbody;
	public float AISpeed;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector3 (AISpeed, 0, 0) * Time.deltaTime); 
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "AI Edge") {
			AISpeed *= -1;
		}
	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
