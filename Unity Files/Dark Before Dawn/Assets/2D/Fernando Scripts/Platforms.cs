using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Platforms : RaycastController {
	public LayerMask passengerMask;
	public Vector3 move;

	List<PassengerMove> passengerMove;

	// Use this for initialization
	public override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateRaycastOrigins ();
		Vector3 velocity = move * Time.deltaTime;

		CalculateMoves(velocity);

		MovePassengers (true);
		transform.Translate (velocity);
		MovePassengers (false);
	}

	void MovePassengers(bool beforeMovePlatform){
		foreach (PassengerMove passenger in passengerMove) {
			if (passenger.moveBeforePlatform == beforeMovePlatform) {
				passenger.transform.GetComponent<Controller2D> ().Move (passenger.velocity);
			}
		}
	}

	void CalculateMoves(Vector3 velocity){
		HashSet<Transform> movedPassengers = new HashSet<Transform> ();
		passengerMove = new List<PassengerMove> ();

		float directionX = Mathf.Sign (velocity.x);
		float directionY = Mathf.Sign (velocity.y);

		if (velocity.y != 0) {
			float rayLength = Mathf.Abs (velocity.y) + skinWidth;
			for (int i = 0; i < verticalRayCount; i++) {
				Vector2 rayOrigin = (directionY == -1) ? raycastOrigins.bottomLeft : raycastOrigins.topLeft;
				rayOrigin += Vector2.right * (verticalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.up * directionY, rayLength, passengerMask);

				if (hit) {
					if(!movedPassengers.Contains(hit.transform)){
						movedPassengers.Add (hit.transform);
						float pushY = velocity.y - (hit.distance - skinWidth) * directionY;
						float pushX = (directionY == 1) ? velocity.x : 0;

						passengerMove.Add(new PassengerMove(hit.transform, new Vector3(pushX, pushY), directionY ==1, true));
					}
				}
			}
		}
		if (velocity.x != 0) {
			float rayLength = Mathf.Abs (velocity.x) + skinWidth;

			for (int i = 0; i < horizontalRayCount; i++) {
				Vector2 rayOrigin = (directionX == -1) ? raycastOrigins.bottomLeft : raycastOrigins.bottomRight;
				rayOrigin += Vector2.up * (horizontalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.right * directionX, rayLength, passengerMask);

				if (hit) {
					if (!movedPassengers.Contains (hit.transform)) {
						movedPassengers.Add (hit.transform);
						float pushY = velocity.x - (hit.distance - skinWidth) * directionX;
						float pushX = (directionY == 1) ? velocity.x : 0;

						passengerMove.Add(new PassengerMove(hit.transform, new Vector3(pushX, pushY), false, true));
					}
				}
			}
		}

		if (directionY == -1 || velocity.y == 0 && velocity.x != 0) {
			float rayLength = skinWidth * 2;

			for (int i = 0; i < verticalRayCount; i++) {
				Vector2 rayOrigin = raycastOrigins.topLeft + Vector2.right * (verticalRaySpacing * i);
				RaycastHit2D hit = Physics2D.Raycast (rayOrigin, Vector2.up, rayLength, passengerMask);

				if (hit) {
					if(!movedPassengers.Contains(hit.transform)){
						movedPassengers.Add (hit.transform);
						float pushY = velocity.y;
						float pushX = velocity.x;

						passengerMove.Add(new PassengerMove(hit.transform, new Vector3(pushX, pushY), true, false));
					}
				}
			}
		}
	}


	struct PassengerMove{
		public Transform transform;
		public Vector3 velocity;
		public bool standingPlatform;
		public bool moveBeforePlatform;

		public PassengerMove(Transform _transform, Vector3 _velocity, bool _standingPlatform, bool _moveBeforePlatform){
			transform = _transform;
			velocity = _velocity;
			standingPlatform = _standingPlatform;
			moveBeforePlatform = _moveBeforePlatform;
		}
	}
}