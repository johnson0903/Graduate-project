using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class BedRoom_BathroomDoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isBathroomDoorOpen;
	private static bool ChangeSceneByBathroomDoor;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (ChangeSceneByBathroomDoor) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			ChangeSceneByBathroomDoor = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if (!isBathroomDoorOpen) {
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("BathroomKey")) {
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("使用 廁所的鑰匙") };
			} else {
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("門關得緊緊的...") };
			}
		} else {
			if (SceneManager.GetActiveScene().buildIndex == 0)
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("通往廁所") };
			else
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("通往臥室") };
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("BathroomKey") || isBathroomDoorOpen) {
			isBathroomDoorOpen = true;
			ChangeSceneByBathroomDoor = true;
			if (player.GetComponent<PlayerInventory> ().isSomethingInInventory ("BathroomKey"))
				player.GetComponent<PlayerInventory> ().DropItem ("BathroomKey");
			if (SceneManager.GetActiveScene ().buildIndex == 0)
				SceneManager.LoadScene (1);
			else {
				SceneManager.LoadScene (0);
			}
		}
	}

}
