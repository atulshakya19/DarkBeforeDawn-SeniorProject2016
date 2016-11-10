using UnityEngine;
using System.Collections;

public class HookFire : MonoBehaviour {

	public GameObject hooking;
	public GameObject hookPoint;

	[HideInInspector]
	public Vector3 mousePosition;
	[HideInInspector]
	public Vector3 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {
			Fire ();
		}

	}

	void Fire(){
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 position = transform.position;
		direction = mousePosition-position;

		var hook = Instantiate(hooking, hookPoint.transform.position, hookPoint.transform.rotation) as GameObject;
	}
}
