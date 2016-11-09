using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour {

	[Header("Attributes")]
	public float turnSpeed = 15f;
	public float msBetweenShoots = 500f;

	[Header("Bullets")]
	public GameObject[] bullets;

	[Header("Shot Effects")]
	public GameObject[] shotEffects;

	[Header("Setup Fields")]
	public Transform shootPosition;


	private Vector3 targetRotation;

	private float nextShotTime;

	private Animator animator;

	void Awake () {
		animator = GetComponent <Animator> ();
	}

	void Update () {
		Turn ();
		Attack ();
	}

	void Turn () {
		transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.Euler (targetRotation), Time.deltaTime * turnSpeed);

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			targetRotation = Vector3.zero;
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			targetRotation = Vector3.down * 180;
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			targetRotation = Vector3.down * -90;
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			targetRotation = Vector3.down * 90;
		}
	}

	void Attack () {
		if (Input.GetKey (KeyCode.A)) {
			StartCoroutine (Shoot (0));
		} else if (Input.GetKey (KeyCode.Z)) {
			StartCoroutine (Shoot (1));
		} else if (Input.GetKey (KeyCode.E)) {
			StartCoroutine (Shoot (2));
		} else if (Input.GetKey (KeyCode.R)) {
			StartCoroutine (Shoot (3));
		}
	}

	IEnumerator Shoot (int index) {
		if (Time.time > nextShotTime) {
			nextShotTime = Time.time + msBetweenShoots / 1000f;
			animator.Play ("Attack");
			yield return new WaitForSeconds (.2f);
			Instantiate (bullets [index], ShootPoints.GetActiveSpawnPoint (shootPosition).position, ShootPoints.GetActiveSpawnPoint (shootPosition).rotation);
			Instantiate (shotEffects [index], ShootPoints.GetActiveSpawnPoint (shootPosition).position, ShootPoints.GetActiveSpawnPoint (shootPosition).rotation);
		}
	}


}
