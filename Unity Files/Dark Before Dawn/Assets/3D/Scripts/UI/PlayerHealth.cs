using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public float fullHealth = 100;
	public float currentHealth;
	public Slider healthBar;

	bool damaged = false;
	bool isDead = false;


	// Use this for initialization
	void Awake () {

		currentHealth = fullHealth;	
		isDead = false;
		damaged = false;

	}
	
	// Update is called once per frame
	void Update (){
		Death ();
	}

	public void isDamaged(int amount){

		if (damaged == true) {

			currentHealth -= amount;

			healthBar.value = currentHealth;

			if (currentHealth <= 0) {
				Death ();
			}
		}

	}

	void Death(){
		if (isDead == true) {
			Destroy (this.gameObject);
		
			RestartLevel ();
		}

	}

	public void RestartLevel()
	{
		SceneManager.LoadScene (0);
	}
}
