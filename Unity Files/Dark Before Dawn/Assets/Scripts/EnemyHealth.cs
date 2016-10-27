using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	//public enum Enemies {enemy1, enemy2, enemy3};

	public int fullHealth = 100;
	public int currentHealth;
	public Slider enemyBar;
	public GameObject enemy;

	bool damaged;
	bool isDead;

	// Use this for initialization
	void Awake () {

		/*switch(Enemies) {
		case Enemies.enemy1:
			fullHealth = 100;
			currentHealth = fullHealth;
			break;

		case Enemies.enemy2:
			fullHealth = 25;
			currentHealth = fullHealth;
			break;

		case Enemies.enemy3:
			fullHealth = 50;
			currentHealth = fullHealth;
			break;


		}*/
		currentHealth = fullHealth;


	}

	// Update is called once per frame
	void Update (){
		/*if (renderer.isVisible) {
			drawGui = true;
		} else {
			drawGui = false;
		}*/
	}

	void OnGUI(){

		Vector2 enemyPos; 
		enemyPos = Camera.main.WorldToScreenPoint(transform.position);

		GUI.Box(new Rect(enemyPos.x, Screen.height- enemy.y, 60, 20), currentHealth + "/" +	fullHealth);
	}

	public void TakeDamage(int amount){

		//if (enemy.Collision) {
			damaged = true;
		//}

		currentHealth -= amount;

		enemyBar.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death ();
		}

	}

	void Death(){

		isDead = true;

	}
}
