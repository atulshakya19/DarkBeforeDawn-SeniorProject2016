using UnityEngine;
using System.Collections;

public class CreateRift : MonoBehaviour {

	private Vector2 _destiny;
	public GameObject rift;

	private GemPickup _gemActive;
	private Rigidbody _rigidbody;
	private MovementScript _move;
	private GameObject riftA;

	public bool _enterRift;
	public bool _riftThere;

	// Use this for initialization
	void Start () {
	
		_move = GetComponent<MovementScript>();
		_rigidbody = GetComponent<Rigidbody> ();
		_gemActive = GetComponent <GemPickup> ();

	}
	
	// Update is called once per frame
	void Update () {

		_destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

		string GemActive = _gemActive.ActiveGem;

		if (GemActive != "Gem 2") {
			Destroy (riftA);
			_riftThere = false;
			_rigidbody.isKinematic = false;
			_move.enabled = true;
			_enterRift = false;
		}

		if (!_riftThere && GemActive == "Gem 2") {
			if (Input.GetKeyDown (KeyCode.Space)) {
				riftA = (GameObject)Instantiate (rift, _destiny, Quaternion.identity);
				_riftThere = true;
			}
		} else if (_enterRift && GemActive == "Gem 2" ) {
			Destroy (riftA);
			_move.enabled = false;
			_rigidbody.isKinematic = true;

			if (Input.GetKeyDown (KeyCode.Space)) {
				transform.position = _destiny;
				_move.enabled = true;
				_enterRift = false;
				_riftThere = false;
				_rigidbody.isKinematic = false;
			}
		} else if (_riftThere && GemActive == "Gem 2" ) {
			if (Input.GetKeyDown (KeyCode.Space)) {
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
