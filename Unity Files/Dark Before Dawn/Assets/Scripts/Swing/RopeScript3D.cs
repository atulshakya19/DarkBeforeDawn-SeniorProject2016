using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RopeScript3D : MonoBehaviour {

	public Vector3 destiny;
	private throwhook _throwhook;

	public float speed= 1;


	public float distance = 10;

	public GameObject nodePrefab;

	public GameObject Player;

	public GameObject lastNode;

	public bool _touch = false;

	private bool _started = false;
	public float RopeLife = 1.5f;


	public LineRenderer lr;

	int vertexCount=2;
	public List<GameObject> Nodes = new List<GameObject>();


	bool done = false;

	// Use this for initialization
	void Start () {

		_throwhook = GetComponent<throwhook> ();

		lr = GetComponent<LineRenderer> ();

		Player = GameObject.FindGameObjectWithTag ("Player");

		lastNode = transform.gameObject;


		Nodes.Add (transform.gameObject);


	}

	// Update is called once per frame
	void Update () {

		/*
		if (!_started)
		{
			StartCoroutine(TimeToDie());
		}
		*/

		if (!_touch) {
			Move ();
		} else {

			if ((Vector3)transform.position != destiny) {

				if (Vector3.Distance (Player.transform.position, lastNode.transform.position) > distance) {


					CreateNode ();

				}


			} else if (done == false) {

				done = true;



				while (Vector3.Distance (Player.transform.position, lastNode.transform.position) > distance) {
					CreateNode ();
				}


				lastNode.GetComponent<HingeJoint> ().connectedBody = Player.GetComponent<Rigidbody> ();
			}
		}


		RenderLine ();
	}


	void RenderLine()
	{

		lr.SetVertexCount (vertexCount);

		int i;
		for (i = 0; i < Nodes.Count; i++) {

			lr.SetPosition (i, Nodes [i].transform.position);

		}

		lr.SetPosition (i, Player.transform.position);

	}


	void CreateNode()
	{

		Vector3 pos2Create = Player.transform.position - lastNode.transform.position;
		pos2Create.Normalize ();
		pos2Create *= distance;
		pos2Create += (Vector3)lastNode.transform.position;

		GameObject go = (GameObject)	Instantiate (nodePrefab, pos2Create, Quaternion.identity);


		go.transform.SetParent (transform);

		lastNode.GetComponent<HingeJoint> ().connectedBody = go.GetComponent<Rigidbody> ();

		lastNode = go;

		Nodes.Add (lastNode);

		vertexCount++;

	}

	void Move (){
		transform.Translate(Vector3.right * Time.deltaTime * 25f);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Swinging Platform") {
			_touch = true;
			destiny = transform.position;
		}
	}

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(RopeLife);

		//Destry the target
		Destroy(gameObject);

	}

}