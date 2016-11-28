using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public float autoLoadNextLevelTime = 3f;

	float currentTime;

	void Update () {
		if (currentTime >= autoLoadNextLevelTime) {
			SceneManager.LoadScene ("MainMenu");
		} else {
			currentTime += Time.deltaTime;
		}
	}

	public void LoadLevel (string levelName) {
		SceneManager.LoadScene (levelName);
		Time.timeScale = 1;
	}
	public void QuitGame () {
		Application.Quit ();
	}

}
