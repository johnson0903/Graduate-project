using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class BedroomDoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isBedroomDoorOpen;
	private static bool ChangeSceneByBedroomDoor;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (ChangeSceneByBedroomDoor) {	
			player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);
			ChangeSceneByBedroomDoor = false;
		}
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
			if (SceneManager.GetActiveScene().buildIndex == 0)
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
			if (SceneManager.GetActiveScene ().buildIndex == 0)
				SceneManager.LoadScene (1);
			else {
				SceneManager.LoadScene (0);
				ChangeSceneByBedroomDoor = true;
			}
		}
	}


}
