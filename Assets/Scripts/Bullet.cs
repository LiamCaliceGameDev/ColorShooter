using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	[Header("Attributes")]
	public string color;
	public float speed = 40f;
	public int damage = 1;
	public LayerMask collisionMask;
	public GameObject impactEffect;

	void Update () {
		float moveDistance = Time.deltaTime * speed;
		transform.Translate (Vector3.forward * moveDistance);
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
			hitEnemy.TakeDamage (damage);
		} else {
			PlayerStats.TakeDamage (hitEnemy.errorShotDamage);
			PlayerNode.HitColorEffect ();
		}

	}

}
