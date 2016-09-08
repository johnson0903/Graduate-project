using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class Bedroom_DoorAI : MonoBehaviour
{
	private GameObject player;
	private DialogHolder dialogHolder;
	private const int DOOR_LOCKED = 0;
	private const int DOOR_OPEN = 1;
	private const int DOOR_CLOSED = 2;
	private static bool isBedroomDoorOpen;
	private static bool ChangeSceneByBedroomDoor;

	// Use this for initialization
	void Start ()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (ChangeSceneByBedroomDoor) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			ChangeSceneByBedroomDoor = false;
		}
	}

	// Update is called once per frame
	void Update ()
	{

		if (!isBedroomDoorOpen) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BedroomKey")) {
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundEffectDialog ("使用 臥室的鑰匙", DOOR_OPEN) };
			} else {
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundEffectDialog ("門關得緊緊的...", DOOR_LOCKED) };
			}
		} else {
			if (SceneManager.GetActiveScene ().buildIndex == 0)
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("通往走廊") };
			else
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("通往臥室") };
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BedroomKey") || isBedroomDoorOpen) {
			isBedroomDoorOpen = true;
			ChangeSceneByBedroomDoor = true;
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BedroomKey"))
				player.GetComponent<PlayerInventory> ().DropItem ("BedroomKey");
			if (SceneManager.GetActiveScene ().buildIndex == 0) {
				SceneManager.LoadScene (4);
			} else {
				SceneManager.LoadScene (0);
			}
		}
	}
}
