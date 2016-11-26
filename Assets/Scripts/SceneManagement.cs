using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour {

	public void LoadLevel (string levelName) {
		SceneManager.LoadScene (levelName);
		Time.timeScale = 1;
	}
	public void QuitGame () {
		Application.Quit ();
	}

}
