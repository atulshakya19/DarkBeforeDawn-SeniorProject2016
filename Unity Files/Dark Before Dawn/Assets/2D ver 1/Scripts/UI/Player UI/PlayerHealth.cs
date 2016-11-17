using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int fullHealth = 5;
	public int currentHealth;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
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

	public void isDamaged(int amount, float timer){
		if (timer > 0) {
			currentHealth -= amount;
			timer -= Time.deltaTime;
		} else {
			timer = timer;
		}

	}

	public void Death(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
