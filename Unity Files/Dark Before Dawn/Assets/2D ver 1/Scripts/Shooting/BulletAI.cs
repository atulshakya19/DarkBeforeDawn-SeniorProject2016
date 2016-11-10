using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BulletAI : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
    //How long should the bullet live
    public float BulletHalfLife;
	public int bulletDamage = 2;
	private GameObject player;
	public float speed = 0.10f;

	private Vector3 playerPosition;

    // Has the spawning started
    private bool _started;

	// Use this for initialization
	void Start ()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerPosition = player.transform.position;
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
			Vector3 direction = (playerPosition - transform.position).normalized;
			float distance = (playerPosition - transform.position).magnitude;
			Vector3 move = transform.position + (direction * speed);
			transform.position = move;
    }

    public void MoveToCursor(Vector3 targetPos)
    {
        transform.Translate(targetPos * Time.deltaTime * 25f);
    }

   /* void OnTriggerEnter (Collider other)
    {
        if (other.transform.tag == "Player")
        {
            
        }
    }*/

	void OnTriggerEnter2D(Collider2D other)
	{
		Debug.Log ("Shoot");
		Destroy(this.gameObject);
		EnemyShoot.bulletNum -= 1;
	}

    // Kill the bullet after bulletHalfLife
    IEnumerator TimeToDie()
    {
        //Indicate that is has started

        _started = true;

        yield return new WaitForSeconds(BulletHalfLife);

        //Destry the target
       
        Destroy(this.gameObject);
		EnemyShoot.bulletNum -= 1;
    }
}