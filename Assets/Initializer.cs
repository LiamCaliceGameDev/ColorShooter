using UnityEngine;
using System.Collections;

public class Initializer : MonoBehaviour {


	void Start () {
		string isLoginOnce  = PlayerPrefs.GetString ("_isLoginOnce");

		if(isLoginOnce != "True") {
			PlayerPrefs.SetString ("_isLoginOnce", "True");
			PlayerPrefs.SetInt ("difficulty", 2);
			PlayerPrefs.SetFloat ("volume", 0.5f);
		}
	}
}
