using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour 
{

	public int fullHealth = 1;
	public int currentHealth;
	public Slider healthBar;

	bool isDead = false;

	// Use this for initialization
	void Awake () 
	{
		currentHealth = fullHealth;
		isDead = false;
	}

	public void isDamaged(int amount)
	{
		if (currentHealth > 0) {
			currentHealth -= amount;
		}
		if(currentHealth <= 0)
		{
			isDead = true;
		}
	}

	void Death ()
	{
			Destroy (this.gameObject);
	}

	// Update is called once per frame
	void Update () 
	{
		if (isDead == true) {
			Death ();
		}
	}
}
