using UnityEngine;
using System.Collections;

public class IsInTalkRange : MonoBehaviour {

	bool canTalk;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Player")) {
			canTalk = true;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		canTalk = false;
	}
}
