using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Vector2 timeBetwwenSpawnsMinMax;
	public GameObject[] enemies;

	private float nextSpawnTime;


	void Start () {
		nextSpawnTime = timeBetwwenSpawnsMinMax.y;
	}

	void Update () {
		if (!PlayerStats.isDead) {
			if (Time.time > nextSpawnTime) {
				float timeBetweenSpawns = Mathf.Lerp (timeBetwwenSpawnsMinMax.y, timeBetwwenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
				nextSpawnTime = Time.time + timeBetweenSpawns;
				SpawnEnemy ();
			}
		}
	}

	private void SpawnEnemy () {
		Instantiate (enemies[Random.Range (0, enemies.Length)], SpawnPoints.GetRandomSpawnPoint ().position, Quaternion.identity);
	}
}
