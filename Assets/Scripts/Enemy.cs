using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	[Header("Attributes")]
	public float speed = 2f;
	public string color;
	public int life = 1;
	public int errorShotDamage = 1;
	public int attackDamage = 1;
	public GameObject deathEffect;


	[Header("Setup Fields")]
	public Transform playerTransform;



	void Start () {
		transform.LookAt (playerTransform.position);	
	}


	
	void Update () {
		if (PlayerStats.isDead) {
			Die ();
		}

		float distanceToPlayer = Vector3.Distance (transform.position, playerTransform.position);

		if (distanceToPlayer <= 2) {
			PlayerStats.TakeDamage(attackDamage);
			Instantiate (deathEffect, transform.position, Quaternion.identity);
			PlayerNode.HitColorEffect ();
			Die ();
		} else {
			transform.Translate (Vector3.forward * Time.deltaTime * speed);
		}

	}

	public void TakeDamage (int amount) {
		life -= amount;
		if (life <= 0f) {
			Die (); 
		}
	}

	private void Die () {
		if (PlayerStats.isDead) {
			GameObject i = Instantiate (deathEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy (i, 3f);
		}
		Destroy (gameObject);


	}
}
