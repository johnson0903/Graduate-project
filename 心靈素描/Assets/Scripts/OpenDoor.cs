using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	
	private Transform player;
	private static bool isGameStart;

	void Start () {

		player = FindObjectOfType<PlayerController> ().gameObject.transform;
		if (isGameStart) {	
			player.position = new Vector3 (this.transform.position.x, player.position.y, player.position.z);
		} else {
			isGameStart = true;
		}
	}


}
