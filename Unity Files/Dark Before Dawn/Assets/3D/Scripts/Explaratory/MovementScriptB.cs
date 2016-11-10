using UnityEngine;
using System.Collections;

public class MovementScriptB: MonoBehaviour {

	Rigidbody rigidBody;
	private GameObject player;
	private RopeScript1 _rope;

	private string lastKey;
	public float speed = 100f;

	private float currentZ;
	private float direction;


	// Use this for initialization
	void Start () {
		_rope = GetComponent<RopeScript1> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_rope._touch) {
			
			if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 180) {
				if (transform.localEulerAngles.z == currentZ) {
					direction *= -1;
					transform.Rotate (new Vector3 (0, 0, direction) * speed / 2 * Time.deltaTime);
				} else {
					transform.Rotate (new Vector3 (0, 0, direction) * speed / 2 * Time.deltaTime);
				}
			}else if (transform.eulerAngles.z < 0 || transform.localEulerAngles.z >180) {	
				direction *= -1;
				transform.Rotate (new Vector3 (0, 0, direction) * speed / 2 * Time.deltaTime);
			} 
		}

		if (Input.GetKey (KeyCode.A)) {
			if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 180) {
				transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
				currentZ = transform.localEulerAngles.z;
				direction = 1;
			}
		} else if (Input.GetKey (KeyCode.D)) {
			if (transform.localEulerAngles.z > 0 && transform.localEulerAngles.z < 180) {
				transform.Rotate (Vector3.forward * speed * Time.deltaTime);
				currentZ = transform.localEulerAngles.z; 
				direction = -1;
			}
		}
			
	}

}
