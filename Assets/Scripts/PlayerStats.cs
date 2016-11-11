using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	[Header("Life")]
	public int startLife = 5;
	public static int Life;


	[Header("Player Reference")]
	public GameObject startplayer;
	private static GameObject Player;


	public static float TimeSurvived;
	public static bool isDead = false;

	void Start () {
		Player = startplayer;
		Life = startLife;
		HealthUI.SetHealthUI ();
	}

	public static void TakeDamage (int amount) {
		if (isDead) {
			return;
		}
		Life -= amount;
		HealthUI.SetHealthUI ();
		if (Life <= 0 && !isDead) {
			Die ();
		}
	}

	private static void Die () {
		isDead = true;
		Destroy (Player);
	}
		
	void Update () {
		if (!isDead) {
			TimeSurvived += Time.deltaTime;
		}
	}

}
