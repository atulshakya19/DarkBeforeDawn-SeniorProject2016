using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	
	public GameObject Bullet;

	public static int bulletNum;


	void OnTriggerStay2D (Collider2D other){
		if (other.transform.tag == "Player" && bulletNum  <1) {
			Instantiate(Bullet,transform.position, Quaternion.identity);
			bulletNum += 1;
		}
	}

}
