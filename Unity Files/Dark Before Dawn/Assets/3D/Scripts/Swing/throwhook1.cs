using UnityEngine;
using System.Collections;

public class throwhook1 : MonoBehaviour {


	public GameObject hook;
	public GameObject hookPoint;
	public bool ropeActive;

	private GemPickup _gemActive;
	GameObject curHook;

	// Use this for initialization
	void Start () {
		
		_gemActive = GetComponent <GemPickup> ();

	}

	// Update is called once per frame
	void Update () {
		
		string GemActive = _gemActive.ActiveGem;

		if (GemActive != "Gem 1") {
			Destroy (curHook);
			ropeActive = false;
		}

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (ropeActive == false && GemActive == "Gem 1") {
				curHook = (GameObject)Instantiate (hook, hookPoint.transform.position, hookPoint.transform.rotation);
				ropeActive = true;
			} else {
				Destroy (curHook);
				ropeActive = false;
			}
		}


	}
}