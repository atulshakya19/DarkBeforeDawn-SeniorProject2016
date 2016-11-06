using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour {

	Controller2D controller;
	Vector3 velocity;
	float gravity;
	float jumpVelocity;
	float accelAir = .2f;
	float accelGround = .1f;
	float velocityXSmooth;

	public float moveSpeed = 6;
	public float jumpHeight = 5;
	public float timeToApex = 0.3f;

	// Use this for initialization
	void Start () {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToApex, 2);
		jumpVelocity = Mathf.Abs(gravity) * timeToApex;
		print ("Gravity" + gravity + " Jump Velocity: " + jumpVelocity);
	}
		
	// Update is called once per frame
	void Update () {
		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		if(Input.GetKeyDown(KeyCode.UpArrow) && controller.collisions.below)
		{
			velocity.y = jumpVelocity;
		}
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

		float TargetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, TargetVelocityX, ref velocityXSmooth, (controller.collisions.below)?accelGround:accelAir);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}


}
