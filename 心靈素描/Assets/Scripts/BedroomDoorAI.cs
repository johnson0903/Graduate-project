using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class BedroomDoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isBedroomDoorOpen;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update () {

		if (!isBedroomDoorOpen) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Key")) {
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("門開了...") };
			} else {
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("門關得緊緊的...") };
			}
		} else {
			if (Application.loadedLevel == 0)
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("通往走廊") };
			else
				dialogHolder.Dialogs = new Dialog[] { dialogHolder.TalkDialog ("通往臥室") };
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Key") || isBedroomDoorOpen) {
			isBedroomDoorOpen = true;
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("Key"))
				player.GetComponent<PlayerInventory> ().DropItem ("Key");
			if (Application.loadedLevel == 0)
				SceneManager.LoadScene (1);
			else
				SceneManager.LoadScene (0);
		}
	}


}
