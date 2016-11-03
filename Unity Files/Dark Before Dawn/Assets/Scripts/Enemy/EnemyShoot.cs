using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	
	public GameObject Bullet;

	public static int bulletNum;


	void OnTriggerStay (Collider other){
		if (other.transform.tag == "Player" && bulletNum  <1) {
			Instantiate(Bullet,transform.position, Quaternion.identity);
			bulletNum += 1;
		}
	}

}
