using UnityEngine;

public class Bullet : MonoBehaviour {

	[Header("Attributes")]
	public string color;
	public float speed = 40f;

	void Update () {
		transform.Translate (Vector3.forward * Time.deltaTime * speed);
	}


}
