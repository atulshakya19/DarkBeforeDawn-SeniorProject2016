using UnityEngine;
using System.Collections;

public class DestroyGem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Player") {
			Destroy (gameObject);
		}
	}
}
