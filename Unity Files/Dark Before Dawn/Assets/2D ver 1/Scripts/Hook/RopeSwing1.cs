using UnityEngine;
using System.Collections;

public class RopeSwing1 : MonoBehaviour {

	public GameObject ropeSpawn;
	private moveHook _moveHook;

	private SpringJoint2D rope;
	public int maxRopeFrameCount;
	private int ropeFrameCount;
	private bool ropeActive = false;

	public LineRenderer lineRenderer;

	void Start () {

		_moveHook = GameObject.FindObjectOfType<moveHook> ();

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
				GameObject.DestroyImmediate (rope);
				ropeFrameCount = 0;
			}
		}
	}

	void Fire (){
		//Vector3 mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector3 position = ropeSpawn.transform.position;
		Vector3 direction = _moveHook.destiny-position;

		//RaycastHit2D hit = Physics2D.Raycast (position, direction, Mathf.Infinity);

		//if (hit.collider != null) {
			//Debug.Log (hit.collider.tag);
			SpringJoint2D newRope = ropeSpawn.AddComponent<SpringJoint2D> ();
			newRope.enableCollision = false;
			newRope.frequency = 0f;
			newRope.connectedAnchor = _moveHook.destiny;
			newRope.enabled = true;

			GameObject.DestroyImmediate (rope);
			rope = newRope;
			ropeFrameCount = 0;
		//}
	}
}
