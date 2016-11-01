using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {
	public Transform Target;
	public Transform Bullet;

	public float maxLOS = 10f;
	public float maxRange = 7f;
	public float minLOS = 2f;

	public float rotDamp = 6f;

	void Update()
	{
		var dis = Vector3.Distance (Target.position, transform.position);
		if (dis <= maxLOS) 
		{
			LookAtTarget ();
			if (dis <= maxRange)
				Shoot (dis);
		//	transform.Translate (transform.forward);
		}
	}

	void LookAtTarget()
	{
		var dir = Target.position - transform.position;
		dir.y = 0;
		var rot = Quaternion.LookRotation (dir);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * rotDamp);
	}

	void Shoot(float dis)
	{
		if(dis > minLOS)
		{
			Instantiate(Bullet, transform.position+(Target.position-transform.position).normalized, Quaternion.LookRotation(Target.position - transform.position));
		}
	}

}
