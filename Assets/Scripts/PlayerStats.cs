﻿using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	public static PlayerStats instance;

	void Awake () {
		if (instance != null) {
			Debug.LogError ("More Than One BuildManager In Scene!");
			return;
		}
		instance = this;
	}
		
	public int Life = 5;
	public int MaxLife = 10;
	public GameObject Player;
	public float TimeSurvived;
	public bool isDead = false;
	public int money = 10;
	public int specialBullets = 10;

	private HealthUI healthUI;
	private GameUI gameUI;


	void Start () {
		healthUI = HealthUI.instance;
		healthUI.SetHealthUI ();
		gameUI = GetComponent <GameUI> ();
	}

	public void TakeDamage (int amount) {
		if (instance.isDead) {
			return;
		}
		SoundManager.instance.PlayerDamageSound ();
		instance.Life -= amount;
		healthUI.SetHealthUI ();
		if (instance.Life <= 0 && !instance.isDead) {
			Die ();
		}
	}

	private void Die () {
		SoundManager.instance.GameEndSound ();
		instance.isDead = true;
		Destroy (instance.Player);
	
		if (instance.TimeSurvived <= PlayerPrefs.GetFloat ("highscore")) {
			gameUI.LoseScreen (false);
			return;
		}
		gameUI.LoseScreen (true);
		PlayerPrefs.SetFloat ("highscore", instance.TimeSurvived);

	}
		
	void Update () {
		if (!isDead) {
			TimeSurvived += Time.deltaTime;
		}

		if (specialBullets < 0) {
			specialBullets = 0;
		}

	}

}
