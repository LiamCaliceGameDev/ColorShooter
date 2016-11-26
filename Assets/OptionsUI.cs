using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

	public Slider difficultySlider;
	public Slider volumeSlider;

	void Start () {
		difficultySlider.value = PlayerPrefs.GetInt ("difficulty");
		volumeSlider.value = PlayerPrefs.GetFloat ("volume");
	}

	public void SaveOptions () {
		PlayerPrefs.SetInt ("difficulty", Mathf.RoundToInt (difficultySlider.value));
		PlayerPrefs.SetFloat ("volume", volumeSlider.value);
	}

}
