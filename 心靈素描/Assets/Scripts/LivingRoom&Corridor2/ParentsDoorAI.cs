using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ParentsDoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private SceneLoader sceneLoader;

	private const int DOOR_LOCKED = 0;
	private const int DOOR_OPEN = 1;

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
		if (!player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("ParentsKey")) {
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog ("門鎖的緊緊的", DOOR_LOCKED, .3f),
				dialogHolder.TalkDialog ("似乎感覺到一股莫名的壓力...")
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.PlaySoundDialog ("你用小鑰匙 開啟了門", DOOR_OPEN, .3f)
			};
	}
		
	void OnDialogOver (object sender, EventArgs e)
	{	
		if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("ParentsKey")) {
			player.GetComponent<PlayerInventory> ().DropItem ("ParentsKey");
			if (SceneManager.GetActiveScene ().buildIndex == 5)
				sceneLoader.LoadSceneAndMovePlayer (8, new Vector3 (-25, player.transform.position.y, 0), 1);
		}
	}

}
