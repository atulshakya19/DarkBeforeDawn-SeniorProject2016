using UnityEngine;
using System.Collections;

public class BulletAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public GameObject enemy;
	public int bulletDamage = 10;

	PlayerHealth playerHealth;
	EnemyHealthBar enemyHealthBar;
	bool lOS;
	float timer;

	void Awake ()
	{
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		playerHealth = enemy.GetComponent <PlayerHealth> ();
		enemyHealthBar = gameObject.GetComponent<EnemyHealthBar>();
	}

	void OnCollisionEnter (Collision other)
	{
		if(other.gameObject.tag == "Enemy")
		{
			lOS = true;
		}
	}


	void OnCollisionExit (Collision other)
	{
		if(other.gameObject.tag == "Enemy")
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
		if(enemyHealthBar.currentHealth > 0)
		{
			enemyHealthBar.isDamaged (bulletDamage);
		}
	}
}
