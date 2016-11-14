 using UnityEngine;
using System.Collections;

public class MovementAI : MonoBehaviour {

	private Rigidbody2D rigidbody;
	public float AISpeed = 2;
	public float speed = 0.10f;
	public GameObject player;


	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (new Vector2 (AISpeed, 0) * Time.deltaTime); 
		rigidbody.freezeRotation = true;
	}

	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "AI Edge") {
			AISpeed *= -1;
		}
	}
		
	public void ChasePlayer(){
		Vector3 direction = (player.transform.position - transform.position).normalized;
		float distance = (player.transform.position - transform.position).magnitude;
		Vector3 move = transform.position + (direction * speed/2);
		transform.position = move;
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.transform.tag == "Player") {
			player.transform.position = transform.position + new Vector3 (-1.5f,0,0);
		}
	}
}
