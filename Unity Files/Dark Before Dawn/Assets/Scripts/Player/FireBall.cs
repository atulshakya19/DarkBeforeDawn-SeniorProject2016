using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour
{

    //spawn the bullet
    public GameObject Bullet;

    //spawn point for bullet
    public GameObject BulletPoint;

    //Spam the bullet
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			FireBullet();
		}

	}

   public void FireBullet()
    {
        //instantiate the bullet
        var bullet = Instantiate(Bullet, BulletPoint.transform.position, BulletPoint.transform.rotation) as GameObject;
    }
}
