using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

	public Text highscoreText;
	public Text timerText;
	public Text moneyText;

	public Color timerRecordColor;

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
	}

}
