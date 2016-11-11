using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour {

	public Text timerText;

	void Update () {
		timerText.text = PlayerStats.TimeSurvived.ToString ();
	}

}
