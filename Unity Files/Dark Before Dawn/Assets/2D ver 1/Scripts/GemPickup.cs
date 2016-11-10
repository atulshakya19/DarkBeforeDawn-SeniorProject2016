using UnityEngine;
using System.Collections;

public class GemPickup : MonoBehaviour {

	public string[] GemBag = new string [3];
	public string ActiveGem;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (Input.GetKeyDown(KeyCode.Alpha1) && GemBag[0] != ""){
			ActiveGem = GemBag [0];
		} else if (Input.GetKeyDown(KeyCode.Alpha2) && GemBag[1] != ""){
			ActiveGem = GemBag [1];
		} else if (Input.GetKeyDown(KeyCode.Alpha3) && GemBag[2] != ""){
			ActiveGem = GemBag [2];
		}
*/

	}

	/*
	void OnTriggerEnter2D (Collider2D other){
		if (other.transform.tag == "Gem 1") {

		}else if (other.transform.tag == "Gem 2") {
			GemBag [1] = other.transform.tag;
		}else if (other.transform.tag == "Gem 3") {
			GemBag [2] = other.transform.tag;
		}
	}
	*/

	public void Gem1(){
		GemBag [0] = "Gem 1";
	}

	public void Gem2(){
		GemBag [1] = "Gem 1";
	}

	public void Gem3(){
		GemBag [2] = "Gem 1";
	}
}
