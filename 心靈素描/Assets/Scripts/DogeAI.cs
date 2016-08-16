using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DogeAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isDogeFed;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isDogeFed) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("好吃好吃"), dialogHolder.TalkDialog ("讓你過") };
			this.GetComponent<BoxCollider2D> ().isTrigger = true;
		} else {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("不給過"), dialogHolder.TalkDialog ("不給過啦") };
			this.GetComponent<BoxCollider2D> ().isTrigger = false;
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
