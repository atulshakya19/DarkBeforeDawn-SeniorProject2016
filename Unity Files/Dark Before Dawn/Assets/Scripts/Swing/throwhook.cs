using UnityEngine;
using System.Collections;

public class throwhook : MonoBehaviour {


	public GameObject hook;
	public GameObject hookPoint;
	public bool ropeActive;

	private RopeScript1 _rope;
	private HingeJoint _joint;
	private HingeJoint _hookJoint;
	private LineRenderer lr;
	private bool jointAdded =false;
	private GemPickup _gemActive;
	public GameObject curHook;

	// Use this for initialization
	void Start () {

		_rope = hook.GetComponent<RopeScript1> ();
		_gemActive = GetComponent <GemPickup> ();
		lr = GetComponent<LineRenderer> ();

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
				//Destroy (_hookJoint);
				Destroy (_joint);
				curHook.GetComponent<RopeScript1> ()._touch = false;
				Destroy (curHook);
				ropeActive = false;
				lr.enabled = false;
				jointAdded = false;;
			}
		}

		if (curHook.GetComponent<RopeScript1>()._touch) {
			Debug.Log ("True");
			//hook.transform.rotation = Quaternion.identity;
			if (!jointAdded) {
				_joint = gameObject.AddComponent<HingeJoint> ();
				_joint.axis = Vector3.back;
				_joint.anchor = Vector3.zero;
				_joint.connectedBody = curHook.GetComponent<Rigidbody> ();
				jointAdded = true;
				_hookJoint = curHook.GetComponent<HingeJoint> ();
				_hookJoint.axis = Vector3.back;
				_hookJoint.anchor = Vector3.zero;
			}
			lr.enabled = true;
		}
			
		lr.SetPosition(0,hookPoint.transform.position);
		lr.SetPosition(1,curHook.transform.position);
	}
}