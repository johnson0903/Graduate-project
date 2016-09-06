using UnityEngine;
using System.Collections;

public class TeleportPlayer : MonoBehaviour {

	public float teleportX;

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			other.transform.position = new Vector3 (teleportX, other.transform.position.y, other.transform.position.z);
	}


}
			
		


 