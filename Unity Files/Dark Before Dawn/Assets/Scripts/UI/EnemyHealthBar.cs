using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour 
{

	public int fullHealth = 100;
	public int currentHealth;
	public Slider healthBar;

	bool damaged;
	bool isDead;

	// Use this for initialization
	void Awake () 
	{
		currentHealth = fullHealth;
		isDead = false;
	
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
		damaged = true;

		currentHealth -= amount;

		healthBar.value = currentHealth;
		if(currentHealth <= 0)
		{
			Death ();
		}
	}

	void Death ()
	{
		isDead = true;
		Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
	
	}
}
