using UnityEngine;
using UnityEngine.UI;
public class GameUI : MonoBehaviour {

	public Text highscoreText;
	public Text timerText;
	public Color timerRecordColor;

	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
		highscoreText.text = PlayerPrefs.GetFloat ("highscore").ToString ();
	}

	void Update () {
		timerText.text = playerStats.TimeSurvived.ToString ();
		if (playerStats.TimeSurvived > PlayerPrefs.GetFloat ("highscore")) {
			timerText.color = timerRecordColor;
		}
	}

}
