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
	public bool turnLeft = false; // bool to see which direction the player is facing

	// Use this for initialization
	void Start () {
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rigidBody.freezeRotation = true;

		//change the direction of the player to face left if he is moving left.
		if (playerMove.x < 0) {
			transform.Rotate (new Vector3 (0, 180, 0));
			turnLeft = true;
		} else if (playerMove.x > 0) {
			turnLeft = false;
		}

		//keep the direction of the player to face the the direction he was facing before coming to a stop.
		if (turnLeft && playerMove.x == 0){
			transform.Rotate (new Vector3 (0, 180, 0));
		}

		if (Input.GetButtonDown ("Vertical") && isGrounded) {
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = true;
		} else if (Input.GetButtonDown ("Vertical") && inAir && doubleJump) {
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = false;
		}
	}

	void FixedUpdate(){
		
		playerMove.Set (Input.GetAxis ("Horizontal"), 0,0);

		if (playerMove == Vector3.zero)
			return;

		Vector3 newPostion = transform.position + playerMove.normalized * moveSpeed * Time.deltaTime;

		rigidBody.MovePosition (newPostion);

		//Quaternion newRotation = Quaternion.LookRotation (playerMove);  

		//if(rigidBody.rotation != newRotation) 
			//rigidBody.rotation = Quaternion.RotateTowards(rigidBody.rotation, newRotation,turnSpeed * Time.deltaTime);
	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Ground") {
			isGrounded = true;
		}
	}

	void OnCollisionExit(Collision col){
		isGrounded = false;
	}
}
