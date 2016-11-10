using UnityEngine;
using System.Collections;

public class moveHook : MonoBehaviour {

	private HookFire _hook;
	private Vector2 _direction;
	private bool _touch = false;

	public Vector3 destiny;

	// Use this for initialization
	void Start () {
		_hook = GameObject.FindObjectOfType<HookFire> ();
		_direction.x = _hook.direction.x;
		_direction.y = _hook.direction.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (!_touch) {

			Move ();
		}

	}

	void Move (){

		transform.Translate (_direction.normalized * Time.deltaTime *25f);
	}
		

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.tag == "Swinging Platform") {
			_touch = true;
			destiny = transform.position;
		}
	}

}
