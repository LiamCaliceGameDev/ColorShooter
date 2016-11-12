using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public static HealthUI instance;

	void Awake () {
		if (instance != null) {
			Debug.LogError ("More Than One HealthUI In Scene!");
			return;
		}
		instance = this;
	}

	public Slider slider;
	public Image fillImage;
	public Color fullHealthColor = Color.green;
	public Color  zeroHealthColor = Color.red;

	private PlayerStats playerStats;

	void Start () {
		playerStats = PlayerStats.instance;
	}

	public void SetHealthUI () {
		
		int playerLife = playerStats.Life;

		slider.value = playerLife;

		if (playerLife == 10) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, 1f);
		} else if (playerLife == 9) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .9f);
		} else if (playerLife == 8) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .8f);
		} else if (playerLife == 7) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .7f);
		} else if (playerLife == 6) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .6f);
		}  else if (playerLife == 5) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .5f);
		} else if (playerLife == 4) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .4f);
		} else if (playerLife == 3) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .3f);
		} else if (playerLife == 2) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .2f);
		} else if (playerLife == 1) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .1f);
		} else if (playerLife <= 0) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, 0f);
		}
	}

}
