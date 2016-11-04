using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour 
{
	public GameObject Bullet;
	public GameObject BulletSpawn;
	public float BulletForce;
	public int attackDamage = 10;

	PlayerHealth playerHealth;
	EnemyHealthBar enemyHealthBar;
	// Use this for initialization

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
		GameObject tempBulletHandle;
		tempBulletHandle = Instantiate (Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation)as GameObject;

		//tempBulletHandle.transform.Rotate (Input.mousePosition.x, Input.mousePosition.y, 1000f);
		Rigidbody tempRigidbody;

		tempRigidbody = tempBulletHandle.GetComponent<Rigidbody> ();

		tempRigidbody.AddForce (transform.forward * BulletForce);

		Destroy (tempBulletHandle);
		var position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1000f);
		position = Camera.main.ScreenToWorldPoint(position);

		var bullet = Instantiate(Bullet, transform.position, Quaternion.identity) as GameObject;
		bullet.transform.LookAt(position);
	}
}
