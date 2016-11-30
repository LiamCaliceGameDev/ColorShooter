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

		if (hitObject.tag == "Flyer") {
			Enemy hitEnemyParent = hitObject.GetComponentInParent <Enemy>();
			OnHitObject (hitEnemyParent);
			return;
		}

		Enemy hitEnemy = hitObject.GetComponent <Enemy>();
		OnHitObject (hitEnemy);
	}


	private void OnHitObject(Enemy hitEnemy) {
		SoundManager.instance.HitEnemySound ();
		GameObject i = Instantiate (impactEffect, transform.position, Quaternion.identity) as GameObject;
		Destroy (i, 3f);

		Destroy (gameObject);

		if (hitEnemy.isSabator) {
			if (color == hitEnemy.color) {
				OnCorrectHit (hitEnemy);
			} else {
				OnWrongHit (hitEnemy);
			}

			return;
		}

		if (color == hitEnemy.color || color == "specialBullet") {
			OnCorrectHit (hitEnemy);
		} else {
			OnWrongHit(hitEnemy);
		}
	}

	private void OnCorrectHit (Enemy hitEnemy) {
		hitEnemy.TakeDamage (damage);
	}

	private void OnWrongHit (Enemy hitEnemy) {

		if (hitEnemy.isSabator) {
			playerStats.specialBullets -= hitEnemy.specialBulletDeduction;
		}

		if (hitEnemy.poisonEffect != null) {
			GameObject i = Instantiate (hitEnemy.poisonEffect, transform.position, Quaternion.identity) as GameObject;
			Destroy (i.gameObject, 3f);
		}
		playerStats.TakeDamage (hitEnemy.errorShotDamage);
		PlayerNode.HitColorEffect ();
	}

}
