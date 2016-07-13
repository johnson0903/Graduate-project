using UnityEngine;
using System.Collections;

public class DogeAI : MonoBehaviour {

	private GameObject player;
	private static bool isDogeFed;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (isDogeFed) {
			this.GetComponent<DialogHolder>().dialogLines = new string[] {"好吃好吃", "讓你過"};
			this.GetComponent<BoxCollider2D> ().isTrigger = true;
		}
	}

	void OnMouseDown ()
	{
		if (!isDogeFed && player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Bone")) {
			isDogeFed = true;
			player.GetComponent<PlayerInventory> ().DropItem ("Bone");
		}
	}
}
