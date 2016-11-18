using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shop : MonoBehaviour {

	[Header("Freeze Power Up")]
	public int freezeCost = 50;
	public float freezeEffectTime = 5f;
	public static bool isFrozen = false;
	public Button freezeButton;
	public GameObject nodeParent;
	public Color freezeColor;
	private Color normalColor;
	public GameObject freezeEffect;
	private Transform[] nodes;

	[Header("Heal Power Up")]
	public int healCost = 25;
	public int healAmount = 2;
	public Button healButton;
	public float healDuration = 2f;
	public GameObject healEffect;



	private PlayerStats playerStats;
	private HealthUI healthUI;



	void Start () {
		playerStats = PlayerStats.instance;
		healthUI = HealthUI.instance;

		nodes = new Transform[nodeParent.transform.childCount];
		for (int i = 0; i < nodeParent.transform.childCount; i++) {
			nodes [i] = nodeParent.transform.GetChild (i);
		}
	}

	void Update () {

		if (playerStats.isDead) {
			freezeButton.interactable = false;
			healButton.interactable = false;
			return;
		}


		if (isFrozen || playerStats.money < freezeCost) {
			freezeButton.interactable = false;
		} 

		if (playerStats.money >= freezeCost && !isFrozen) {
			freezeButton.interactable = true;
		} 

		if (playerStats.money < healCost) {
			healButton.interactable = false;
		} 

		if (playerStats.money >= healCost) {
			healButton.interactable = true;
		}

	}

	// Freeze Power Up
	public void FreezePowerUp () {

		if (playerStats.money < freezeCost && !isFrozen) {
			Debug.Log ("Not Enough Money!");
			return;
		}
		StartCoroutine (StartFreezeEffect());
	}

	IEnumerator StartFreezeEffect() {
		playerStats.money -= freezeCost;
		isFrozen = true;
		foreach (Transform node in nodes) {
			Renderer nodeRenderer = node.GetComponent <Renderer>();
			normalColor = nodeRenderer.material.color;
			nodeRenderer.material.color = freezeColor;
		}
		for (int i = 0; i < GameObject.FindObjectsOfType <Enemy>().Length; i++) {
			GameObject freezeEffectInstance = Instantiate (freezeEffect, GameObject.FindObjectsOfType <Enemy>()[i].transform.position + Vector3.up * 3, Quaternion.identity) as GameObject;
			Destroy (freezeEffectInstance, freezeEffectTime);
		}
		yield return new WaitForSeconds (freezeEffectTime);
		isFrozen = false;
		foreach (Transform node in nodes) {
			Renderer nodeRenderer = node.GetComponent <Renderer>();
			nodeRenderer.material.color = normalColor;
		}
		if (playerStats.money >= freezeCost) {
			freezeButton.interactable = true;
		}
	}

	// Heal Power Up

	public void Heal () {

		if (playerStats.money < healCost) {
			Debug.Log ("Not Enough Money!");
			return;
		}

		if (playerStats.isDead == true) {
			Debug.Log ("Can't Use That Because Player Is Dead!");
			return;
		}

		StartCoroutine (StartHeal());

	}


	IEnumerator StartHeal () {
		playerStats.money -= healCost;
		playerStats.Life += healAmount;
		if (playerStats.Life > playerStats.MaxLife) {
			playerStats.Life = playerStats.MaxLife;
		}
		healthUI.SetHealthUI ();
		GameObject i = Instantiate (healEffect, playerStats.Player.transform.position + Vector3.up * 3, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds (healDuration);
		Destroy (i);
	}



}
