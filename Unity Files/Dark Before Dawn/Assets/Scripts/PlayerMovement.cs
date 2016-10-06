using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float MoveSpeed;    
	public float JumpHeight;
	public float FallSpeed;

	private Vector3 _moveDirection;
	private CharacterController _characterController; 

	// Use this for initialization
	void Start () 
	{
		// Zero out the _moveDirection
		_moveDirection = Vector3.zero;

		// Cache a copy of the CharacterController
		_characterController = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
	}

	public void Movement(){
		
		// Make sure the character is touching the ground
		if (_characterController.isGrounded)
		{
			// If the jump button (space) is pressed
			if (Input.GetButton("Jump"))
			{
				// Set the y value (up) of move direction to Jump Height
				_moveDirection.y = JumpHeight;
			}
		}

		// Get the horizontal (a/d) and the vertical (w/s) values
		_moveDirection = transform.TransformDirection(Input.GetAxis("Horizontal"), 0, 0);

		// Apply the movement speed
		_moveDirection *= MoveSpeed;

		// Pull the character back down
		_moveDirection.y -= FallSpeed * Time.deltaTime;

		// Move the character
		_characterController.Move(_moveDirection * Time.deltaTime);
	}
}
