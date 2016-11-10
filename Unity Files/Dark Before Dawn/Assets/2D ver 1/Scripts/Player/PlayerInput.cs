using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player))]
public class PlayerInput : MonoBehaviour {

	Player player;


	void Start () {
		player = GetComponent<Player> ();
	}

	void Update () {
		Vector2 directionalInput = new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		player.SetDirectionalInput (directionalInput);


		if (Input.GetKeyDown(KeyCode.UpArrow)|| Input.GetKeyUp (KeyCode.W)) {
			player.OnJumpInputDown ();
		}
		if (Input.GetKeyUp (KeyCode.UpArrow) || Input.GetKeyUp (KeyCode.W)) {
			player.OnJumpInputUp ();
		}
	}
}
