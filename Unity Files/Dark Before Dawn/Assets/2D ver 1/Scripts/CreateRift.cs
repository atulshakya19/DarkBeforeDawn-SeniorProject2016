using UnityEngine;
using System.Collections;

public class CreateRift : MonoBehaviour {

	private Vector2 _destiny;
	public GameObject rift;

	private GemPickup _gemActive;
	private Rigidbody _rigidbody;
	private MovementScript _move;
	private GameObject riftA;
	private float currentSpeed;
	public bool _enterRift;
	public bool _riftThere;

	// Use this for initialization
	void Start () {
	
		_move = GetComponent<MovementScript>();
		_rigidbody = GetComponent<Rigidbody> ();
		_gemActive = GetComponent <GemPickup> ();

		currentSpeed = _move.moveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		_destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		string GemActive = _gemActive.ActiveGem;

		if (GemActive != "Gem 2") {
			Destroy (riftA);
			_riftThere = false;
			_rigidbody.isKinematic = false;
			_move.moveSpeed = currentSpeed;
			_enterRift = false;
		}

		if (!_riftThere && GemActive == "Gem 2") {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				riftA = (GameObject)Instantiate (rift, _destiny, Quaternion.identity);
				_riftThere = true;
			}
		} else if (_enterRift && GemActive == "Gem 2" ) {
			Destroy (riftA);
			_move.moveSpeed = 0;
			_rigidbody.isKinematic = true;

			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				transform.position = _destiny;
				_move.moveSpeed = currentSpeed;
				_enterRift = false;
				_riftThere = false;
				_rigidbody.isKinematic = false;
			}
		} else if (_riftThere && GemActive == "Gem 2" ) {
			if (Input.GetKeyDown (KeyCode.UpArrow)) {
				Destroy (riftA);
				_riftThere = false;
			}
		}
	}


	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Rift") {
			_enterRift = true;	
		}
	}
}
