using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour {

	public Slider difficultySlider;
	public Slider volumeSlider;

	public Sprite easyImage;
	public Sprite mediumImage;
	public Sprite hardImage;

	public Image difficultyImage;

	void Start () {
		difficultySlider.value = PlayerPrefs.GetInt ("difficulty");
		volumeSlider.value = PlayerPrefs.GetFloat ("volume");
	}
		

	public void SaveOptions () {
		PlayerPrefs.SetInt ("difficulty", Mathf.RoundToInt (difficultySlider.value));
		PlayerPrefs.SetFloat ("volume", volumeSlider.value);
	}

	public void onSliderValueChanged () {
		if (difficultySlider.value == 1) {
			difficultyImage.sprite = easyImage;
		} else if (difficultySlider.value == 2) {
			difficultyImage.sprite = mediumImage;
		} else if (difficultySlider.value == 3) {
			difficultyImage.sprite = hardImage;
		}
	}

}
