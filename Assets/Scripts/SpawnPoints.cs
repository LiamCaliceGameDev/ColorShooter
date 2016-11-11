using UnityEngine;
using System.Collections;

public class SpawnPoints : MonoBehaviour {


	private static Transform[] spawnPoints;
	private static Transform activeSpawnPoint;

	void Awake () {
		spawnPoints = new Transform [transform.childCount];
		for (int i = 0; i < spawnPoints.Length; i++) {
			spawnPoints [i] = transform.GetChild (i);
		}
	}


	public static Transform GetRandomSpawnPoint () {
		
		activeSpawnPoint = spawnPoints[Random.Range (0, spawnPoints.Length)];

		if (activeSpawnPoint != null) {
			return activeSpawnPoint;
		} else {
			return null;
		}
	}

}
