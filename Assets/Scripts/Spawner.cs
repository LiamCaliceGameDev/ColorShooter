using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float timeBetwwenSpawns = 3.5f;
	public GameObject[] enemies;

	private float nextSpawnTime;

	void Start () {
		nextSpawnTime = timeBetwwenSpawns;
	}

	void Update () {
		if (Time.time > nextSpawnTime) {
			nextSpawnTime = Time.time + timeBetwwenSpawns;
			SpawnEnemy ();
		}
	}

	private void SpawnEnemy () {
		Instantiate (enemies[Random.Range (0, enemies.Length)], SpawnPoints.GetRandomSpawnPoint ().position, Quaternion.identity);
	}


}
