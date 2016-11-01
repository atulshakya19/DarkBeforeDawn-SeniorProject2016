using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	public GameObject Enemy;
	public GameObject Bullet;
	public GameObject BulletPoint;
	public int attackDamage = 10;

	PlayerHealth playerHealth;
	EnemyHealthBar enemyHealthBar;
	// Use this for initialization
	void Start () 
	{
		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyHealthBar = gameObject.GetComponent<EnemyHealthBar>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButtonDown(0))
		{
			FireBullet();
		}
	}

	public void FireBullet()
	{
		var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000f);
		position = Camera.main.ScreenToWorldPoint(position);

		var bullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
		bullet.transform.LookAt(position);
	}

	void OnCollision(Collision other)
	{
		// Make sure it is only Player objects
		if (other.transform.tag == "Enemy")
		{
			enemyHealthBar.isDamaged (attackDamage);
		}
	}
}
