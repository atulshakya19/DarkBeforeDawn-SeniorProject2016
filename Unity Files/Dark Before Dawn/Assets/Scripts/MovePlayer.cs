using UnityEngine;
using System.Collections;

public class MovePlayer : MonoBehaviour {

	public float moveSpeed = 5f;
	public float jumpDistance = 10f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (KeyCode.D)) {
			transform.Translate (moveSpeed * Time.deltaTime, 0f, 0f);
		} else if (Input.GetKey (KeyCode.A)) {
			transform.Translate (-moveSpeed * Time.deltaTime, 0f, 0f);
		}
			
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (0, jumpDistance* Time.deltaTime, 0) ;
		}
	}
}
