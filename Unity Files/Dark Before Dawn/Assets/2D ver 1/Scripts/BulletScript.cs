using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {


	public float BulletHalfLife;
	private bool _started;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		//is the spawn timer has not started. Start it

		if (!_started)
		{
			StartCoroutine(TimeToDie());
		}

		Move();
	}

	//Move the bullet

	void Move()
	{
		transform.Translate (Vector2.right * Time.deltaTime * 25f);
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy") {
			print ("HIT!!!");
			Destroy(this.gameObject);
		}
	}
	// Kill the bullet after bulletHalfLife

	IEnumerator TimeToDie()
	{
		//Indicate that is has started

		_started = true;

		yield return new WaitForSeconds(BulletHalfLife);

		//Destry the target

		Destroy(this.gameObject);
	}
}
