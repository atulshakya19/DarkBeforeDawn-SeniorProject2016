using UnityEngine;
using System.Collections;

public class DestroyScript : MonoBehaviour {
	public float destroyDelay = 3.0f;


	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, destroyDelay);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
