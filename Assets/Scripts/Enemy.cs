using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Header("Attributes")]
	public string color;
	public int life = 1;
	public float speed = 2f;
	public int errorShotDamage = 1;
	public int attackDamage = 1;
	public GameObject deathEffect;
	public Vector2 deathMoneyMiMax;

	[Header("Optional")]
	public GameObject poisonEffect;


	[Header("Setup Fields")]
	public Transform playerTransform;

	private PlayerStats playerStats;


	void Start () {
		playerStats = PlayerStats.instance;
		transform.LookAt (playerTransform.position);	
	}
		
	void Update () {
		if (playerStats.isDead) {
			Die ();
			return;
		}

		if (Shop.isFrozen) {
			return;
		}
				
		DetectReachPlayer ();
	}

	private void DetectReachPlayer () {
		float distanceToPlayer = Vector3.Distance (transform.position, playerTransform.position);

		if (distanceToPlayer <= 2) {
			OnReachPlayer ();
		} else {
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}
	}

	private void OnReachPlayer () {
		playerStats.TakeDamage(attackDamage);
		Instantiate (deathEffect, transform.position, Quaternion.identity);
		PlayerNode.HitColorEffect ();
		Die ();
	}

	public void TakeDamage (int amount) {
		life -= amount;
		if (life <= 0f) {
			playerStats.money += Mathf.RoundToInt (Random.Range (deathMoneyMiMax.x, deathMoneyMiMax.y));
			Die (); 
		}
	}
 
	private void Die () {
		if (playerStats.isDead) {
			GameObject i = Instantiate (deathEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy (i, 3f);
		}
		Destroy (gameObject);
	}







}
