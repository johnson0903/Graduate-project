using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class Bedroom_DoorAI : MonoBehaviour
{
	private GameObject player;
	private DialogHolder dialogHolder;
	private SceneLoader sceneLoader;

	private const int DOOR_LOCKED = 0;
	private const int DOOR_OPEN = 1;
	private const int DOOR_CLOSED = 2;

	private static bool isBedroomDoorOpen;
	private static bool hasDialogPopUpInCorridor;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		dialogHolder = this.GetComponent<DialogHolder>();
		sceneLoader = FindObjectOfType<SceneLoader>();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isBedroomDoorOpen)
		{
			if (player.GetComponent<PlayerInventory>().IsSomethingInInventory("BedroomKey"))
			{
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("使用 臥室的鑰匙", DOOR_OPEN, .3f) };
			}
			else {
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("門關得緊緊的...", DOOR_LOCKED, .3f) };
			}
		}
		else
		{
			if (SceneManager.GetActiveScene().buildIndex == 1)
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("通往走廊", DOOR_OPEN, .3f) };
			else
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog("通往臥室", DOOR_OPEN, .3f) };
		}
	}

	void OnDialogOver(object sender, EventArgs e)
	{
		isBedroomDoorOpen = true;
		if (player.GetComponent<PlayerInventory>().IsSomethingInInventory("BedroomKey"))
			player.GetComponent<PlayerInventory>().DropItem("BedroomKey");
		if (SceneManager.GetActiveScene().buildIndex == 1)
		{
			sceneLoader.LoadSceneAndMovePlayer(4, new Vector3(0, player.transform.position.y, 0), 1);
		}
		else {
			sceneLoader.LoadSceneAndMovePlayer(1, new Vector3(28, player.transform.position.y, 0), -1);
		}
	}
}
