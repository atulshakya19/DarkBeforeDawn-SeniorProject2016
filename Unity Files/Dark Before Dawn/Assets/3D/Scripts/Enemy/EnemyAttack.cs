using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public float timeBetweenAttacks = 0.5f;
	public GameObject player;
	public int attackDamage = 10;

	PlayerHealth playerHealth;
	EnemyHealthBar enemyHealthBar;
	bool lOS;
	float timer;

	void Awake ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerHealth> ();
		enemyHealthBar = gameObject.GetComponent<EnemyHealthBar>();
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			lOS = true;
		}
	}


	void OnCollisionExit (Collision other)
	{
		if(other.gameObject.tag == "Player")
		{
			lOS = false;
		}
	}

	void Update ()
	{
		timer += Time.deltaTime;
		if(timer >= timeBetweenAttacks && lOS && enemyHealthBar.currentHealth > 0)
		{
			Attack ();
		}
	}


	void Attack ()
	{
		timer = 0f;
		if(playerHealth.currentHealth > 0)
		{
			playerHealth.isDamaged (attackDamage);
		}
	}
}
