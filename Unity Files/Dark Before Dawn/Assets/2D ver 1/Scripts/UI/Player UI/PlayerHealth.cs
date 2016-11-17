using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public int fullHealth = 5;
	public int currentHealth;

	private Player _player;
	private bool hitting;
	private float slowTime = 6f;

	// Use this for initialization
	void Start () {
		currentHealth = fullHealth;
		_player = GetComponent<Player> ();
	}
	
	// Update is called once per frame
	void Update (){

		if (hitting) {
			slowTime -= Time.deltaTime;
			if (slowTime > 5) {
				_player.moveSpeed = 1;
			} else if (slowTime > 4) {
				_player.moveSpeed = 2;
			} else if (slowTime > 3) {
				_player.moveSpeed = 3;
			} else if (slowTime > 2) {
				_player.moveSpeed = 4;
			} else if (slowTime > 1) {
				_player.moveSpeed = 5;
			} else if (slowTime > 0) {
				_player.moveSpeed = 6;
				hitting = false;
			}
		}

		if (currentHealth > fullHealth) {
			currentHealth = fullHealth;
		}

		if (currentHealth <= 0) {
			Death ();
		}
	}

	public void isDamaged(int amount){
		if (currentHealth > 0) {
			currentHealth -= amount;
			//timer -= Time.deltaTime;
		} 

	}

	public void Death(){
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Bullet AI") {
			hitting = true;
			slowTime = 6f;
		}
	}
}
