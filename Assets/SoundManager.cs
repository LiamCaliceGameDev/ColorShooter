using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	public AudioSource[] sounds;

	public static SoundManager instance;

	void Start () {
		instance = this;
	}

	public void ShootSound () {
		sounds[0].Play ();
	}

	public void SpecialBulletSound () {
		sounds[1].Play ();
	}

	public void HitEnemySound () {
		sounds[2].Play ();
	}

	public void PlayerDamageSound () {
		sounds[3].Play ();
	}

	public void SoundFreeze () {
		sounds[4].Play ();
	}

	public void BuyBulletsSound () {
		sounds[5].Play ();
	}

	public void HealSound () {
		sounds[6].Play ();
	}

	public void GameEndSound () {
		sounds[7].Play ();
	}


}
