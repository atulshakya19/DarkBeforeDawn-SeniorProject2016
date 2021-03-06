﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bullet : MonoBehaviour {

    //How long should the bullet live
    public float BulletHalfLife;
	public int damage = 2;

    // Has the spawning started
    private bool _started;
	private Vector3 _direction;
	private GameObject _enemy;
	private GameObject _player;
	private MovementScript _playerMove;
	private EnemyHealthBar _enemyHealth;
	private PlayerHealth _playerHealth;

	bool lOS = false;
	float timer;
	public float timeBetweenAttacks = 0.5f;

	// Use this for initialization
	void Start ()
    {
		_enemy = GameObject.FindGameObjectWithTag ("Enemy");
		_enemyHealth = _enemy.GetComponent<EnemyHealthBar> ();
		_player = GameObject.FindGameObjectWithTag("Player");
		_playerMove = _player.GetComponent<MovementScript> ();

		if (_playerMove.facingRight) {
			_direction = Vector3.right;
		}  else if (_playerMove.facingRight == false) {
			_direction = Vector3.left;
		}
			
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
			transform.Translate (_direction * Time.deltaTime * 25f);
    }

    public void MoveToCursor(Vector3 targetPos)
    {
        transform.Translate(targetPos * Time.deltaTime * 25f);
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "Enemy") {
			print ("HIT!!!");
			lOS = true;
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
