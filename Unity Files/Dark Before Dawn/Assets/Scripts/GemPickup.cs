using UnityEngine;
using System.Collections;

public class GemPickup : MonoBehaviour {

	private int GemCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other){
		if (other.transform.tag == "Gems") {
			GemCount += 1;
			Debug.Log ("You Have " + GemCount + " Gems in the Bag.");
		}
	}
}
