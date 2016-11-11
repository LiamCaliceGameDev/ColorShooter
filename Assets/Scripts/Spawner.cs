using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Vector2 timeBetweenSpawnsMinMax;
	public GameObject[] enemies;

	private float nextSpawnTime;

	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
		nextSpawnTime = timeBetweenSpawnsMinMax.y;
	}

	void Update () {
		if (playerStats.isDead) {
			return;
		}
		if (Time.time > nextSpawnTime) {
			float timeBetweenSpawns = Mathf.Lerp (timeBetweenSpawnsMinMax.y, timeBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			nextSpawnTime = Time.time + timeBetweenSpawns;
			SpawnEnemy ();
		}
	}

	private void SpawnEnemy () {
		Instantiate (enemies[Random.Range (0, enemies.Length)], SpawnPoints.GetRandomSpawnPoint ().position, Quaternion.identity);
		// TODO: instantiate spawn particle effect
	}
}
