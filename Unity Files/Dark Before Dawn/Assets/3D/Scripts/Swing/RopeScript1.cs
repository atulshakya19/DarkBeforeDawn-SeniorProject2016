using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RopeScript1: MonoBehaviour {

	public Vector2 destiny;
	private throwhook _throwhook;

	public float speed= 1;


	public float distance = 1;

	public GameObject Player;
	private Vector3 _direction;
	private MovementScript _playerMove;

	public bool _touch = false;

	private bool _started = false;
	public float RopeLife = 1.5f;


	// Use this for initialization
	void Start () {

		_throwhook = GetComponent<throwhook> ();

		Player = GameObject.FindGameObjectWithTag ("Player");
		_playerMove = Player.GetComponent<MovementScript> ();

		if (_playerMove.facingRight) {
			_direction = Vector3.right;
		}  else if (_playerMove.facingRight == false) {
			_direction = Vector3.left;
		}

	}

	// Update is called once per frame
	void Update () {

		/*
		if (!_started)
		{
			StartCoroutine(TimeToDie());
		}
		*/


		if (!_touch) {
			
			Move ();
		}

	}


	void Move (){
		transform.Translate(_direction * Time.deltaTime * 25f);
	}

	void OnTriggerEnter (Collider col){
		if (col.gameObject.tag == "Swinging Platform") {
			_touch = true;
			destiny = transform.position;
		}
	}

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(RopeLife);

		//Destry the target
		Destroy(gameObject);
	}

}