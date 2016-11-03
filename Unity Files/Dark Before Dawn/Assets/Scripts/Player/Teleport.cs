using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	public Transform a2;
	public Transform b2;
	public Transform c2;
	public Transform d2;
	public Transform e2;
	public Transform f2;
	public Transform g2;


	void Update(){

	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Teleport1a") {
			this.transform.position = a2.position;
			print ("wee a1");
		}
		if (col.gameObject.tag == "Teleport1b") {
			this.transform.position = b2.position;
			print ("wee b1");
		}
		if (col.gameObject.tag == "Teleport1c") {
			this.transform.position = c2.position;
		}
		if (col.gameObject.tag == "Teleport1d") {
			this.transform.position = d2.position;
		}
		if (col.gameObject.tag == "Teleport1e") {
			this.transform.position = e2.position;
		}
		if (col.gameObject.tag == "Teleport1f") {
			this.transform.position = f2.position;
		} 
		if (col.gameObject.tag == "Teleport1g") {
			this.transform.position = g2.position;
		}
	}
}
