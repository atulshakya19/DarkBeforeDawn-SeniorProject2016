using UnityEngine;
using System.Collections;

public class FireAtCursor : MonoBehaviour
{

    //the ball we are firing out
    private FireBall _fireball;

    //if we can fire

	// Use this for initialization
	void Start ()
    {
        _fireball = transform.GetComponent<FireBall>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetMouseButtonDown(0))
            {
                _fireball.FireBullet();
            }

	}
}
