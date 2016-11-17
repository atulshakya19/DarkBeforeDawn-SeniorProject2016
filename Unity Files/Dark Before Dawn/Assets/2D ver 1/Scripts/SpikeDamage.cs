using UnityEngine;
using System.Collections;

public class SpikeDamage : MonoBehaviour {
	public int damage = 1;

	private PlayerHealth playerFruit;

	void Start(){
		playerFruit = GameObject.FindObjectOfType<PlayerHealth> ();
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.transform.tag == "Ground" ||  other.transform.tag == "Through" || other.transform.tag == "Swinging Platform") {
			Destroy (gameObject);
		}

		if (other.transform.tag == "Player") {
			Destroy (gameObject);
			playerFruit.isDamaged (damage);
		}
	}
}
