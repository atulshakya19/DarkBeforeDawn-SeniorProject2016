using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	Controller2D controller;
	Vector3 velocity;
	float gravity;
	float moveSpeed = 6;
	float jumpVelocity;

	float jumpHeight = 5;
	float timeToApex = 0.3f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = (2 * jumpHeight) / Mathf.Pow (timeToApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToApex;
	}
		
	// Update is called once per frame
	void Update () {
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow))
			{
			velocity.y = jumpVelocity;

		}
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		velocity.x = input.x * moveSpeed;
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}


}
