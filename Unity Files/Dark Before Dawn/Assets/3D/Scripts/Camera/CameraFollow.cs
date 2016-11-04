using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	private GameObject _player;
	public Vector3 distance;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag ("Player");
		distance = (transform.position - _player.transform.position);

	}
	
	// Update is called once per frame
	void Update () {

		transform.position = _player.transform.position + distance;
	
	}
}
