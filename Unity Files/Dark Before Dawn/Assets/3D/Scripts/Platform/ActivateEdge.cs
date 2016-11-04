using UnityEngine;
using System.Collections;

public class ActivateEdge : MonoBehaviour {

	private GameObject parentAI;
	private GameObject LEdge;
	private GameObject REdge;
	private Collider MEdge;
	// Use this for initialization
	void Start () {
		parentAI = transform.parent.gameObject;
		LEdge = parentAI.transform.FindChild ("AI LEdge").gameObject;
		REdge = parentAI.transform.FindChild ("AI REdge").gameObject;
		MEdge = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider col){
		if (col.transform.tag == "Enemy") {
			LEdge.GetComponent<BoxCollider> ().enabled = true;
			REdge.GetComponent<BoxCollider> ().enabled = true;
			MEdge.enabled = false;

		}
	}
}
