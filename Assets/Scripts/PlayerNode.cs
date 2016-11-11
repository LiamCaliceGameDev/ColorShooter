using UnityEngine;
using System.Collections;

public class PlayerNode : MonoBehaviour {

	public Color startHitColor;

	public static PlayerNode instance;

	static Renderer rend;
	static Color startColor;
	static Color hitColor;

	void Awake () {
		instance = this;
		rend = GetComponent <Renderer> ();
		startColor = rend.material.color;
		hitColor = startHitColor;
	}
		

	static IEnumerator HitColorEffectStart () {
		rend.material.color = hitColor;
		yield return new WaitForSeconds (.05f);
		rend.material.color = startColor;
	}

	public static void HitColorEffect() {
		instance.StartCoroutine (HitColorEffectStart ());
	}	
		

}
