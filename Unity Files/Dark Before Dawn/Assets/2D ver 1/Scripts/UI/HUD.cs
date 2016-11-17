using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {

	public GameObject player;

	public Sprite[] healthFruits;

	public Image healthUI;

	private PlayerHealth playerHealth;


	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		healthUI.sprite = healthFruits[playerHealth.currentHealth];
	}
}
