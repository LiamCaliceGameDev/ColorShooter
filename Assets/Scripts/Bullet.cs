using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[Header("Attributes")]
	public string color;
	public float speed = 40f;
	public int damage = 1;
	public LayerMask collisionMask;
	public GameObject impactEffect;

	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
	}

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}

	void OnTriggerEnter (Collider hitObject) {
		if (hitObject.tag == "BulletStopper") {
			Destroy (gameObject);
			return;
		}
		Enemy hitEnemy = hitObject.GetComponent <Enemy>();
		OnHitObject (hitEnemy);
	}


	private void OnHitObject(Enemy hitEnemy) {
		GameObject i = Instantiate (impactEffect, transform.position, Quaternion.identity) as GameObject;
		Destroy (i, 3f);

		Destroy (gameObject);

		if (color == hitEnemy.color) {
			OnCorrectHit (hitEnemy);
		} else {
			OnWrongHit(hitEnemy);
		}
	}

	private void OnCorrectHit (Enemy hitEnemy) {
		hitEnemy.TakeDamage (damage);
	}

	private void OnWrongHit (Enemy hitEnemy) {
		playerStats.TakeDamage (hitEnemy.errorShotDamage);
		PlayerNode.HitColorEffect ();
	}

}
