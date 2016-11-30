using UnityEngine;
using System.Collections;

public class BGMusic : MonoBehaviour {

	private static BGMusic instance = null;

	void Awake() {
		if (instance != null && instance != this) {
			DestroyImmediate(this.gameObject);
			return;
		} else {
			instance = this;
		}
		DontDestroyOnLoad(this.gameObject);
	}

	void Start () {
		GetComponent <AudioSource>().volume = PlayerPrefs.GetFloat ("volume");
	}

}
