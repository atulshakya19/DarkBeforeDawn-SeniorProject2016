using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int fullHealth = 100;
	public int currentHealth;
	public Slider healthBar;

	bool damaged;
	bool isDead;

	// Use this for initialization
	void Awake () {

		currentHealth = fullHealth;	

	}
	
	// Update is called once per frame
	void Update (){
	
	}

	public void TakeDamage(int amount){

		damaged = true;

		currentHealth -= amount;

		healthBar.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}

	}

	void Death(){

		isDead = true;

	}
}
