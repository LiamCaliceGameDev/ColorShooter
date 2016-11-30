using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	[Header("Easy")]
	public Vector2 timeBetweenSpawnsMinMaxEasy;

	[Header("Medium")]
	public Vector2 timeBetweenSpawnsMinMaxMedium;

	[Header("Hard")]
	public Vector2 timeBetweenSpawnsMinMaxHard;


	private Vector2 timeBetweenSpawnsMinMax;

	public GameObject[] enemies;

	private float nextSpawnTime;

	private PlayerStats playerStats;

	void Start () {
		if (PlayerPrefs.GetInt ("difficulty") == 1) {
			timeBetweenSpawnsMinMax = timeBetweenSpawnsMinMaxEasy;
		} else if (PlayerPrefs.GetInt ("difficulty") == 2) {
			timeBetweenSpawnsMinMax = timeBetweenSpawnsMinMaxMedium;
		} else if (PlayerPrefs.GetInt ("difficulty") == 3) {
			timeBetweenSpawnsMinMax = timeBetweenSpawnsMinMaxHard;
		} else {
			timeBetweenSpawnsMinMax = timeBetweenSpawnsMinMaxMedium;
		}

		playerStats = PlayerStats.instance;
		nextSpawnTime = timeBetweenSpawnsMinMax.y;
	}

	void Update () {
		if (playerStats.isDead || Shop.isFrozen) {
			return;
		}
		if (Time.time > nextSpawnTime) {
			float timeBetweenSpawns = Mathf.Lerp (timeBetweenSpawnsMinMax.y, timeBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent ());
			nextSpawnTime = Time.time + timeBetweenSpawns;
			SpawnEnemy ();
		}
		Debug.Log (Difficulty.GetDifficultyPercent ());
	}

	private void SpawnEnemy () {
		Instantiate (enemies[Random.Range (0, enemies.Length)], SpawnPoints.GetRandomSpawnPoint ().position, Quaternion.identity);
		// TODO: instantiate spawn particle effect
	}
}
