using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {


	public int fullHealth = 100;
	public int currentHealth;
	public Slider healthBar;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;	
		healthBar.maxValue = fullHealth;
		healthBar.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update (){

		if (currentHealth > fullHealth) {
			currentHealth = fullHealth;
		}

		if (currentHealth <= 0) {
			Death ();
		}
	}

	public void isDamaged(int amount){
		currentHealth -= amount;

		healthBar.value = currentHealth;
	}

	void Death(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
