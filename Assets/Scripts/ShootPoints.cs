using UnityEngine;
using System.Collections;

public class ShootPoints : MonoBehaviour {


	private static Transform[] spawnPoints;
	private static Transform activeSpawnPoint;

	void Awake () {
		spawnPoints = new Transform [transform.childCount];
		for (int i = 0; i < spawnPoints.Length; i++) {
			spawnPoints [i] = transform.GetChild (i);
		}
	}


	public static Transform GetActiveSpawnPoint (Transform playerTransform) {
		float nearestDistance = Mathf.Infinity;

		foreach (Transform spawnPoint in spawnPoints) {
			float distance = Vector3.Distance (spawnPoint.position, playerTransform.position);
			if (distance < nearestDistance) {
				nearestDistance = distance;
				activeSpawnPoint = spawnPoint;
			}
		}

		if (activeSpawnPoint != null) {
			return activeSpawnPoint;
		} else {
			return null;
		}
	}

}
