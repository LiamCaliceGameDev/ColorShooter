using UnityEngine;
using System.Collections;

public class PlayerNode : MonoBehaviour {

	public Color startHitColor;
	public Color startFreezeColor;

	public static PlayerNode instance;

	static Renderer rend;
	static Color startColor;
	static Color hitColor;
	static Color freezeColor;

	void Awake () {
		instance = this;
		rend = GetComponent <Renderer> ();
		startColor = rend.material.color;
		hitColor = startHitColor;
		freezeColor = startFreezeColor;
	}
		

	static IEnumerator HitColorEffectStart () {
		rend.material.color = hitColor;
		yield return new WaitForSeconds (.05f);
		rend.material.color = startColor;
		if (Shop.isFrozen) {
			rend.material.color = freezeColor;
		}
	}

	public static void HitColorEffect() {
		instance.StartCoroutine (HitColorEffectStart ());
	}	
		

}
