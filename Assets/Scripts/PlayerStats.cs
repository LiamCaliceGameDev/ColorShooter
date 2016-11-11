using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[Header("Life")]
	public static int Life;
	public int startLife = 5;

	[Header("Health Bar")]
	public Slider startSlider;
	public Image startFillImage;
	public Color startFullHealthColor = Color.green;
	public Color  startZeroHealthColor = Color.red;

	[Header("Setup Fields")]
	public GameObject startplayer;



	private static Slider slider;
	private static Image fillImage;
	private static Color fullHealthColor = Color.green;
	private static Color  zeroHealthColor = Color.red;

	private static GameObject player;


	public static bool isDead = false;

	void Start () {
		player = startplayer;

		slider = startSlider;
		fillImage = startFillImage;
		fullHealthColor = startFullHealthColor;
		zeroHealthColor = startZeroHealthColor;

		Life = startLife;
		SetHealthUI ();
	}

	public static void TakeDamage (int amount) {
		if (!isDead) {
			Life -= amount;
			SetHealthUI ();
			if (Life <= 0 && !isDead) {
				Die ();
			}
		}
	}

	private static void Die () {
		isDead = true;
		Destroy (player);
	}

	private static void SetHealthUI () {
		slider.value = Life;

		if (Life == 5) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, 1f);
		} else if (Life == 4) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .8f);
		} else if (Life == 3) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .6f);
		} else if (Life == 2) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .4f);
		} else if (Life == 1) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, .2f);
		}  else if (Life <= 0) {
			fillImage.color = Color.Lerp (zeroHealthColor, fullHealthColor, 0f);
		}
	}

}
