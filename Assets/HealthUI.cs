using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

	public Slider slider;
	public Image fillImage;
	public Color fullHealthColor = Color.green;
	public Color  zeroHealthColor = Color.red;

	private static Slider i_slider;
	private static Image i_fillImage;
	private static Color i_fullHealthColor = Color.green;
	private static Color  i_zeroHealthColor = Color.red;


	void Start () {
		i_slider = slider;
		i_fillImage = fillImage;
		i_fullHealthColor = fullHealthColor;
		i_zeroHealthColor = zeroHealthColor;
	}

	public static void SetHealthUI () {
		
		int playerLife = PlayerStats.Life;

		i_slider.value = playerLife;

		if (playerLife == 5) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, 1f);
		} else if (playerLife == 4) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, .8f);
		} else if (playerLife == 3) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, .6f);
		} else if (playerLife == 2) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, .4f);
		} else if (playerLife == 1) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, .2f);
		}  else if (playerLife <= 0) {
			i_fillImage.color = Color.Lerp (i_zeroHealthColor, i_fullHealthColor, 0f);
		}
	}

}
