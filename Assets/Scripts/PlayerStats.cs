using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public static int Life;
	public int startLife = 5;

	private static bool isDead = false;

	void Start () {
		Life = startLife;
	}

	public static void TakeDamage (int amount) {
		if (!isDead) {
			Life -= amount;
			if (Life <= 0) {
				Die ();
			}
		}
	}

	private static void Die () {
		isDead = true;
		Debug.Log ("PLAYER DEAD"); 
	}

}
