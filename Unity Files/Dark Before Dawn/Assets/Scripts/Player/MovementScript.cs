using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	Rigidbody rigidBody;
	public float moveSpeed;
	public float jumpHeight;
	public float jumpPushForce = 10f;
	public float jumpForce = 700f;
	Vector3 playerMove;

	bool isGrounded = false;
	bool inAir = false;
	public bool doubleJump = false;
	public bool touchingWall = false;
	public bool facingRight = true; // bool to see which direction the player is facing


	// Use this for initialization
	void Start () {
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		rigidBody.freezeRotation = true;

		if (playerMove.x > 0 && !facingRight) {
			Flip ();
		} else if (playerMove.x < 0 && facingRight) {
			Flip ();
		}

		if (Input.GetButtonDown ("Vertical")) {
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = true;
		} else if (Input.GetButtonDown ("Vertical") && inAir && doubleJump) {
			rigidBody.AddForce (new Vector3 (0f, jumpHeight, 0), ForceMode.Impulse);
			inAir = false;
		}

		if (touchingWall && Input.GetButtonDown ("Vertical")) {
			WallJump ();
		}
	}

	void FixedUpdate(){

		if (touchingWall) {
			isGrounded = false;
			doubleJump = false;
		}

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

		if (col.transform.tag == "Wall Jump") {
			touchingWall = true;
		}
	}

	void OnCollisionStay (Collision col){
		if (col.transform.tag == "Ground") {
			isGrounded = true;
			doubleJump = true;
		}

	}

	void OnCollisionExit(Collision col){
		if (col.transform.tag == "Ground") {
			isGrounded = false;
		}
		if (col.transform.tag == "Wall Jump") {
			touchingWall = false;
			Debug.Log (touchingWall);
		}
	}

	void Flip(){
		facingRight = !facingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void WallJump(){
		rigidBody.AddForce(jumpPushForce,jumpForce,0);
	}
		
}
