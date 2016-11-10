using UnityEngine;
using System.Collections;

public class RopeSwing : MonoBehaviour {

	public GameObject ropeSpawn;
	private GameObject player;

	private SpringJoint2D rope;
	public int maxRopeFrameCount;
	private int ropeFrameCount;
	private bool ropeActive = false;

	LayerMask layermask = 1 << 13;
	public LineRenderer lineRenderer;


	void Start (){
		player = GameObject.FindGameObjectWithTag ("Player");
		ropeSpawn.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (1)) {
			ropeSpawn.transform.position = player.transform.position;  //ok
			if (ropeActive == false /*&& GemActive == "Gem 1"*/) {
				//ropeSpawn.SetActive (true);
				//player.SetActive (false);
				ropeSpawn.transform.position = player.transform.position;  //ok
				Fire ();
				ropeActive = true;
			} else {
				player.SetActive (true);									//ok
				player.transform.position = ropeSpawn.transform.position;	//ok
				GameObject.DestroyImmediate (rope);
				ropeSpawn.SetActive (false);								//ok
				ropeFrameCount = 0;
				ropeActive = false;
			}

		}

		if (Input.GetKeyDown (KeyCode.A)){
			Rigidbody2D rb = ropeSpawn.GetComponent<Rigidbody2D>();
			rb.AddForce (new Vector2 (-10,0),ForceMode2D.Impulse);
		} else if (Input.GetKeyDown (KeyCode.D)){
			Rigidbody2D rb = ropeSpawn.GetComponent<Rigidbody2D>();
			rb.AddForce (new Vector2 (10,0),ForceMode2D.Impulse);
		}

	}

	void LateUpdate(){
		if (rope != null) {
			lineRenderer.enabled = true;
			lineRenderer.SetVertexCount (2);
			lineRenderer.SetPosition (0, ropeSpawn.transform.position);
			lineRenderer.SetPosition (1, rope.connectedAnchor);
		} else {
			lineRenderer.enabled = false;
		}
	}

	void FixedUpdate(){
		if (rope != null) {
			ropeFrameCount++;

			if (ropeFrameCount > maxRopeFrameCount) {
				player.SetActive (true);									//notok
				player.transform.position = ropeSpawn.transform.position;	//notok
				GameObject.DestroyImmediate (rope);
				ropeSpawn.SetActive (false);								//notok
				ropeFrameCount = 0;
				ropeActive = false;
			}
		}
	}

	void Fire (){
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 position = player.transform.position;
		Vector3 direction = mousePosition-position;

		RaycastHit2D hit = Physics2D.Raycast (position, direction, 100.0f, layermask);

		if (hit.collider != null) {
			player.SetActive (false);
			ropeSpawn.SetActive (true);
			ropeSpawn.transform.position = player.transform.position;

			SpringJoint2D newRope = ropeSpawn.AddComponent<SpringJoint2D> ();
			newRope.enableCollision = false;
			newRope.frequency = 0f;
			newRope.connectedAnchor = hit.point;
			newRope.enabled = true;

			GameObject.DestroyImmediate (rope);
			rope = newRope;
			ropeFrameCount = 0;
		}
	}
}
