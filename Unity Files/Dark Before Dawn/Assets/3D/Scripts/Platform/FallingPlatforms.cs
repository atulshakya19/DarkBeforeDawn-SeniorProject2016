using UnityEngine;
using System.Collections;

public class FallingPlatforms : MonoBehaviour {

	private Collider platformCol;
	private Rigidbody rigidbody;

	//How long should the bullet live
	public float platformTime =5f;

	// Has the spawning started
	private bool _started;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnCollisionEnter (Collision col){
		if (col.transform.tag == "Player") {
			if (!_started)
			{
				StartCoroutine(TimeToDie());
			}


			rigidbody.freezeRotation = true;
		}
	}

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(platformTime);

		//Destry the target
		rigidbody = gameObject.AddComponent<Rigidbody> ();
	}

}
