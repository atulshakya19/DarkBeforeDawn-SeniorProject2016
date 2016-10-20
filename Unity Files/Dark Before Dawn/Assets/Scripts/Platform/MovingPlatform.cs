using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	public Transform b;
	private bool yes = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (yes) {
			
		}
	}

	void OnTriggerEnter (Collider col){

		if (col.transform.tag == "Player") {
			yes = true;
			transform.rotation = Quaternion.EulerAngles (new Vector3 (0,0,90));
		}
	}
}
