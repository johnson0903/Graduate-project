using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	
	public float cameraMinX;
	public float cameraMaxX;

	private Transform player;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject.transform;
	}

	// Update is called once per frame
	void FixedUpdate() {
		if (player) {
			float cameraX = player.position.x;
			if (cameraX < cameraMinX)
				cameraX = cameraMinX;
			else if (cameraX > cameraMaxX)
				cameraX = cameraMaxX;
			transform.position = Vector3.Lerp (transform.position, new Vector3(cameraX, 0.0f, player.position.z), 0.1f) + new Vector3 (0, 0, -10);
		}
	}
}
