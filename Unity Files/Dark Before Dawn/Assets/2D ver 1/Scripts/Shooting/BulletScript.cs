using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	public float BulletHalfLife;
	private bool _started;
	private bool _facingRight = true;
	private Controller2D _controller;


	// Use this for initialization
	void Start () {
	
		_controller = GameObject.FindObjectOfType<Controller2D> ();

		if (_controller.collisions.faceDir > 0) {
			_facingRight = true;
		} else if (_controller.collisions.faceDir < 0) {
			_facingRight = false;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{
		//is the spawn timer has not started. Start it

		if (!_started)
		{
			StartCoroutine(TimeToDie());
		}

		Move();
	}

	//Move the bullet

	void Move()
	{
		if (_facingRight) {
			transform.Translate (Vector2.right * Time.deltaTime * 25f);
		} else {
			transform.Translate (Vector2.left * Time.deltaTime * 25f);
		}
	}


	void OnTriggerEnter2D(Collider2D other)
	{
			//Destroy(this.gameObject);
	}
	// Kill the bullet after bulletHalfLife

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(BulletHalfLife);

		//Destry the target

		Destroy(this.gameObject);
	}
}
