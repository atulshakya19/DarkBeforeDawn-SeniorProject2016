using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SlowBullet : MonoBehaviour {

	public float BulletHalfLife;
	public int damage = 2;
	private GameObject player;
	public float speed = 0.10f;

	private Vector3 playerPosition;

	// Has the spawning started
	private bool _started;
	private PlayerHealth _playerHealth;
	private MovementScript _playerSpeed;


	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//_playerHealth = player.GetComponent<PlayerHealth> ().currentHealth;
		//_playerSpeed = player.GetComponent<MovementScript> ().moveSpeed;
		playerPosition = player.transform.position;
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
		Vector3 direction = (playerPosition - transform.position).normalized;
		float distance = (playerPosition - transform.position).magnitude;
		Vector3 move = transform.position + (direction * speed);
		transform.position = move;
	}

	public void MoveToCursor(Vector3 targetPos)
	{
		transform.Translate(targetPos * Time.deltaTime * 25f);
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.transform.tag == "Player")
		{
			Destroy(this.gameObject);
			EnemyShoot.bulletNum -= 1;
		}
	}

	void OnCollision(Collider other)
	{
		if (other.transform.tag == "Player") {
			//_playerHealth - damage;
		}
		if (other.transform.tag == "Player") {
			//_playerSpeed = 0;
		}
	}

	// Kill the bullet after bulletHalfLife

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(BulletHalfLife);

		//Destry the target

		Destroy(this.gameObject);
		EnemyShoot.bulletNum -= 1;
	}

}