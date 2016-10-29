using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {

	private float _mouseY;
	public bool _invertedMouse = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (_invertedMouse) {
			_mouseY += Input.GetAxis ("Mouse Y");
		} else {
			_mouseY -= Input.GetAxis ("Mouse Y");
		}

		transform.eulerAngles = new Vector3 (0,0, _mouseY*2);

	}
}
