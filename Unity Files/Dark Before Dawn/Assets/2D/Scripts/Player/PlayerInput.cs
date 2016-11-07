using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;
	bool canDoubleJump;

	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		player.SetDirectionalInput (directionalInput);


		if (Input.GetButton(KeyCode.UpArrow)) {
			if (canDoubleJump) {
				player.OnJumpInputDown ();
			}
		}
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			player.OnJumpInputUp ();
		}
	}
}
