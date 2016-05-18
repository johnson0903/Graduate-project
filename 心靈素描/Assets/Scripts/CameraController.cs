using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Transform player;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (player) {
			transform.position = Vector3.Lerp (transform.position, new Vector3(player.position.x,0.0f,player.position.z), 0.1f) + new Vector3 (0, 0, -10);
		}
	}
}
