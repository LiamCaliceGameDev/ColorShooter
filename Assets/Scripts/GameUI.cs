using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameUI : MonoBehaviour {

	public Text highscoreText;
	public Text timerText;
	public Text moneyText;
	public Text specialBulletsText;
	public GameObject pauseMenu;
	public Button pauseButton;

	public Color timerRecordColor;
	public Color zeroOfSomethingColor;

	public GameObject loseScreen;
	public GameObject recordText;
	public Text secondsSurvived;

	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
		highscoreText.text = string.Format ("{0:00.00}", PlayerPrefs.GetFloat ("highscore"));
	}

	void Update () {
		timerText.text = string.Format ("{0:00.00}", playerStats.TimeSurvived);

		moneyText.text = playerStats.money.ToString ();
		if (playerStats.TimeSurvived > PlayerPrefs.GetFloat ("highscore")) {
			timerText.color = timerRecordColor;
		}

		specialBulletsText.text = playerStats.specialBullets.ToString ();

		if (playerStats.money <= 0) {
			moneyText.color = zeroOfSomethingColor;
		}

		if (playerStats.specialBullets <= 0) {
			specialBulletsText.color = zeroOfSomethingColor;
		}

		if (playerStats.money > 0) {
			moneyText.color = Color.white;
		}

		if (playerStats.specialBullets > 0) {
			specialBulletsText.color = Color.white;
		}

		if (playerStats.isDead) {
			pauseButton.interactable = false;
		} else {
			pauseButton.interactable = true;
		}

	}


	public void PauseButton () {
		if (playerStats.isDead) {
			return;
		}
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
	}

	public void ContinueButton () {
		Time.timeScale = 1;
		pauseMenu.SetActive (false);
	}

	public void LoseScreen (bool record) {
		loseScreen.SetActive (true);
		secondsSurvived.text = Mathf.RoundToInt (playerStats.TimeSurvived).ToString ();
		if (record) {
			recordText.SetActive (true);
		} else {
			recordText.SetActive (false);
		}

	}


}
