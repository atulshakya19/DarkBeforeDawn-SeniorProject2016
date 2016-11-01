using UnityEngine;
using System.Collections;

public class MovementScriptB: MonoBehaviour {

	Rigidbody rigidBody;
	private GameObject player;
	private RopeScript1 _rope;

	private string lastKey;
	public float speed = 100f;

	public float currentZ;


	// Use this for initialization
	void Start () {
		_rope = GetComponent<RopeScript1> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		rigidBody = transform.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_rope._touch) {

			//Debug.Log (transform.localEulerAngles.z);
			if (transform.localEulerAngles.z < 90) {
				transform.Rotate (new Vector3 (0, 0, currentZ/180) * speed / 2 * Time.deltaTime);
			} else if (transform.localEulerAngles.z >90) {
				transform.Rotate (new Vector3 (0, 0, currentZ/180) * -speed / 2 * Time.deltaTime);
			}


		}


		if (Input.GetKey (KeyCode.A)){
			transform.Rotate (-Vector3.forward * speed * Time.deltaTime);
			currentZ = transform.localEulerAngles.z; 
			lastKey = "A";
			//Debug.Log (currentZ);
		}else if (Input.GetKey (KeyCode.D)){
			transform.Rotate (Vector3.forward * speed * Time.deltaTime);
			currentZ = transform.localEulerAngles.z; 
			lastKey = "D";
		}
			
	}

}
