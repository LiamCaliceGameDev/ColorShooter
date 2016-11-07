using UnityEngine;

public class Player : MonoBehaviour {

	void Update () {

		Turn ();

	}

	void Turn () {
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			transform.rotation = Quaternion.Euler (Vector3.zero);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.rotation = Quaternion.Euler (Vector3.down * 180);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.rotation = Quaternion.Euler (Vector3.down * -90);
		} else if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.rotation = Quaternion.Euler (Vector3.down * 90);
		}
	}

}
