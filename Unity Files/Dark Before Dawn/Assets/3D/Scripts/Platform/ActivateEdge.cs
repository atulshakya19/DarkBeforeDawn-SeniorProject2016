using UnityEngine;
using System.Collections;

public class ActivateEdge : MonoBehaviour {

	private GameObject parentAI;
	private GameObject LEdge;
	private GameObject REdge;
	private Collider2D MEdge;
	// Use this for initialization
	void Start () {
		parentAI = transform.parent.gameObject;
		LEdge = parentAI.transform.FindChild ("AI LEdge").gameObject;
		REdge = parentAI.transform.FindChild ("AI REdge").gameObject;
		MEdge = GetComponent<BoxCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.transform.tag == "Enemy") {
			LEdge.GetComponent<BoxCollider2D> ().enabled = true;
			REdge.GetComponent<BoxCollider2D> ().enabled = true;
			MEdge.enabled = false;

		}
	}
}
