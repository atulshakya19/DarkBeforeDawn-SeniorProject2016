using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

	public float maxJump = 4;
	public float minJump = 1;
	public float timeApex = .4f;
	float accelAir = .2f;
	float accelGround = .1f;
	public float moveSpeed = 6;

	public Vector2 wallJumpClimb;
	public Vector2 wallJumpOff;
	public Vector2 wallLeap;

	public float wallSlideSpeedMax = 3;
	public float stickTime = .25f;
	float unstickTime;

	float gravity;
	float maxJumpVelocity;
	float minJumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	public float doubleJump = 5;
	public bool canDoubleJump;

	Controller2D controller;

	Vector2 directionalInput;
	bool wallSliding;
	int wallDirX;

	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * maxJump) / Mathf.Pow (timeApex, 2);
		maxJumpVelocity = Mathf.Abs(gravity) * timeApex;
		minJumpVelocity = Mathf.Sqrt (2 * Mathf.Abs (gravity) * minJump);
	}

	void Update() {

		CalculateVelocity ();
		HandleWallSliding ();


		controller.Move (velocity * Time.deltaTime, directionalInput);

		if (controller.collisions.above || controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				velocity.y += controller.collisions.slopeNormal.y * -gravity * Time.deltaTime;
			} else {
				velocity.y = 0;
			}
		}
	}

	public void SetDirectionalInput (Vector2 input) {
		directionalInput = input;
	}

	public void OnJumpInputDown() {
		if (wallSliding) {
			if (wallDirX == directionalInput.x) {
				velocity.x = -wallDirX * wallJumpClimb.x;
				velocity.y = wallJumpClimb.y;
			}
			else if (directionalInput.x == 0) {
				velocity.x = -wallDirX * wallJumpOff.x;
				velocity.y = wallJumpOff.y;
			}
			else {
				velocity.x = -wallDirX * wallLeap.x;
				velocity.y = wallLeap.y;
			}
		}
		if (controller.collisions.below) {
			if (controller.collisions.slidingDownMaxSlope) {
				if (directionalInput.x != -Mathf.Sign (controller.collisions.slopeNormal.x)) { // not jumping against max slope
					velocity.y = maxJumpVelocity * controller.collisions.slopeNormal.y;
					velocity.x = maxJumpVelocity * controller.collisions.slopeNormal.x;
				}
			} else {
				velocity.y = maxJumpVelocity;
				canDoubleJump = true;
			}
		} else if (canDoubleJump) {
			canDoubleJump = false;
			velocity.y = maxJumpVelocity;
		}
	}

	public void OnJumpInputUp() {
		if (velocity.y > minJumpVelocity) {
			velocity.y = minJumpVelocity;
		}
	}
		

	void HandleWallSliding() {
		if (controller.canWallJump == true) {
			wallDirX = (controller.collisions.left) ? -1 : 1;
			wallSliding = false;
			if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0) {
				wallSliding = true;

				if (velocity.y < -wallSlideSpeedMax) {
					velocity.y = -wallSlideSpeedMax;
				}

				if (unstickTime > 0) {
					velocityXSmoothing = 0;
					velocity.x = 0;

					if (directionalInput.x != wallDirX && directionalInput.x != 0) {
						unstickTime -= Time.deltaTime;
					} else {
						unstickTime = stickTime;
					}
				} else {
					unstickTime = stickTime;
				}
			}
		}
	}
	

	void CalculateVelocity() {
		float targetVelocityX = directionalInput.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?accelGround:accelAir);
		velocity.y += gravity * Time.deltaTime;
	}

	/*public IEnumerator Knockback(float knockDur, float knockPow, Vector3 knockDir){

		float timer = 0;
		while (knockDur > 0) {
			timer += Time.deltaTime;
			velocity.y = new Vector3 (knockDir.x * -10, knockDir.y*knockPow, transform.position.z);
		}
		yield return 0;
	}*/
}
