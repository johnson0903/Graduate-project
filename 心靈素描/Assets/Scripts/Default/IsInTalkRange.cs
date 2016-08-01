using UnityEngine;
using System.Collections;

public class IsInTalkRange : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other) {
		if (other.CompareTag ("Item") || other.CompareTag ("NPC")) {
			DialogHolder dHolder = other.GetComponent<DialogHolder> ();
			if (dHolder != null) {
				dHolder.EnterRange ();
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Item") || other.CompareTag ("NPC")) {
			DialogHolder dHolder = other.GetComponent<DialogHolder> ();
			if (dHolder != null) {
				dHolder.LeaveRange ();
			}
		}
	}
}
