using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth = 100;
	public float currentHealth;
	public Slider healthBar;

	bool damaged;


	// Use this for initialization
	void Awake () {

		currentHealth = fullHealth;	
		enemyAi.isDead = false;

	}
	
	// Update is called once per frame
	void Update (){
		if (currentHealth < 0) 
		{
			Destroy(gameObject);
		}
	
	}

	public void isDamaged(int amount){

		damaged = true;

		currentHealth -= amount;

		healthBar.value = currentHealth;

		if (currentHealth <= 0 && !enemyAi.isDead) {
			Death ();
		}

	}

	void Death(){



	}

	public void RestartLevel()
	{
		SceneManager.LoadScene (0);
	}
}
