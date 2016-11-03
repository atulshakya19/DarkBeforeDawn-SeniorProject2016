using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour 
{

	public int fullHealth = 100;
	public int currentHealth;
	public Slider healthBar;

	bool damaged = false;
	bool isDead = false;

	// Use this for initialization
	void Awake () 
	{
		currentHealth = fullHealth;
		isDead = false;
		damaged = false;
	}

	void OnCollision (Collider col)
	{
		if(col.gameObject.tag == "Bullet")
		{
			currentHealth -= gameObject.GetComponent<Bullet>().damage;
		}
	}

	public void isDamaged(int amount)
	{
		if (damaged == true) {

			currentHealth -= amount;
		}
		healthBar.value = currentHealth;
		if(currentHealth <= 0)
		{
			isDead = true;
		}
	}

	void Death ()
	{
		if (isDead == true) {
			Destroy (this.gameObject);
		}
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Death ();
		//isDamaged ();
	}
}
