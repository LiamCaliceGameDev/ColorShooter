using UnityEngine;
using System.Collections;

public class ShootPoints : MonoBehaviour {


	private static Transform[] shootPoints;
	private static Transform activeShootPoint;

	void Awake () {
		shootPoints = new Transform [transform.childCount];
		for (int i = 0; i < shootPoints.Length; i++) {
			shootPoints [i] = transform.GetChild (i);
		}
	}

	public static Transform GetActiveShootPoint (Transform playerTransform) {
		float nearestDistance = Mathf.Infinity;

		foreach (Transform spawnPoint in shootPoints) {
			float distance = Vector3.Distance (spawnPoint.position, playerTransform.position);
			if (distance < nearestDistance) {
				nearestDistance = distance;
				activeShootPoint = spawnPoint;
			}
		}

		if (activeShootPoint != null) {
			return activeShootPoint;
		} else {
			return null;
		}
	}

}
