using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	Rigidbody rigidBody;
	public float moveSpeed;
	public float jumpHeight;
	Vector3 playerMove;

	bool isGrounded = false;
	bool inAir = false;
	public bool doubleJump = false;

	// Use this for initialization
	void Start () {
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rigidBody.freezeRotation = true;

		if (Input.GetButtonDown ("Vertical") && isGrounded) {
			Debug.Log ("Up");
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = true;
		} else if (Input.GetButtonDown ("Vertical") && inAir && doubleJump) {
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = false;
		}
	}

	void FixedUpdate(){

		playerMove.Set (Input.GetAxis ("Horizontal"), 0,0);

		Vector3 newPostion = transform.position + playerMove.normalized * moveSpeed * Time.deltaTime;

		rigidBody.MovePosition (newPostion);

	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Ground") {
			Debug.Log ("Grounded");
			isGrounded = true;
		}
	}
	//POOOOOOOOOOOOP!
	void OnCollisionExit(Collision col){
		isGrounded = false;
	}
}
