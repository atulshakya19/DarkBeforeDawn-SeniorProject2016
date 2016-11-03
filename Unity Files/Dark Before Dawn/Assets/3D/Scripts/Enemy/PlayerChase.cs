using UnityEngine;
using System.Collections;

public class PlayerChase : MonoBehaviour {

	public float speed = 0.10f;
	public GameObject player;
	private MovementAI enemy;
	Vector3 move;

	private GameObject parentEnemy;
	private GameObject parentAI;
	private GameObject LEdge;
	private GameObject REdge;
	private GameObject MEdge;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = transform.parent.GetComponent<MovementAI>();

		parentEnemy = transform.parent.gameObject;
		parentAI = parentEnemy.transform.parent.gameObject;
		LEdge = parentAI.transform.FindChild ("AI LEdge").gameObject;
		REdge = parentAI.transform.FindChild ("AI REdge").gameObject;
		MEdge = parentAI.transform.FindChild ("AI MEdge").gameObject;
		MEdge.GetComponent<BoxCollider> ().enabled = false;
	}

	void OnTriggerStay (Collider col){
		if (col.transform.tag == "Player") {
			LEdge.GetComponent<BoxCollider> ().enabled = false;
			REdge.GetComponent<BoxCollider> ().enabled = false;
			enemy.AISpeed = 0;
			enemy.ChasePlayer ();
		}
	}

	void OnTriggerExit (Collider col){
		if (col.transform.tag == "Player") {
			ActivateAIEdges ();

		}
	}

	public void ActivateAIEdges (){
		MEdge.GetComponent<BoxCollider> ().enabled = true;
		enemy.AISpeed = 2;
		Vector3 direction = (MEdge.transform.position - parentEnemy.transform.position).normalized;
		float distance = (MEdge.transform.position - parentEnemy.transform.position).magnitude;
		Vector3 move = transform.position + (direction * speed);
		parentEnemy.transform.position = move;
	}
}
