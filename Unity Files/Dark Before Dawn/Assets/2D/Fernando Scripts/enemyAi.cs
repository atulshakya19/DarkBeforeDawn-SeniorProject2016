using UnityEngine;
using System.Collections;

public class enemyAi : MonoBehaviour {
	public Transform player;
	public float playerDistance;
	public float rotDamp;
	public float moveSpeed;

	public static bool isDead = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		playerDistance = Vector3.Distance (player.position, transform.position);
		if (isDead = false) 
		{
			if (playerDistance < 8f) 
			{
				LookAtPlayer ();
				print ("I see you!!!");
			}
			if (playerDistance < 5f) 
			{
				if (playerDistance > 1f) 
				{
					Follow ();
					print ("Here comes JONNY!!!");
				} else if (playerDistance < 5f) {
					Shoot ();
				}
			}
		}
	}

	void LookAtPlayer()
	{
		Quaternion rotation = Quaternion.LookRotation (player.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotDamp);
	}

	void Follow()
	{
		transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

	}

	void Shoot ()
	{
		RaycastHit hit;
		if(Physics.Raycast(transform.position, transform.forward, out hit))
		{
			if(hit.collider.gameObject.tag == "Player")
			{
				hit.collider.gameObject.GetComponent <PlayerHealth> ().currentHealth -= 10f;
			}
		}
	}
}
