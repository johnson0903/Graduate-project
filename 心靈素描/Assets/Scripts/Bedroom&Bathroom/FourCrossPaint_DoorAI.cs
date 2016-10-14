﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class FourCrossPaint_DoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private SceneLoader sceneLoader;

	private static bool hasDialogPopUpInFourCrossPaint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		sceneLoader = FindObjectOfType<SceneLoader> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if(SceneManager.GetActiveScene ().buildIndex == 7 && !hasDialogPopUpInFourCrossPaint)
			dialogHolder.IsAutoPopUp = true;
	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().buildIndex == 6) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("牆上掛著一幅奇怪的畫"),
				dialogHolder.AskDialog ("繼續盯著看", "離開", new List<Dialog> {
					dialogHolder.TalkDialog ("有種奇怪的感覺...")
				}), dialogHolder.TalkDialog ("感覺...意志要被吸進去了")
			};
		} else {
			if (!hasDialogPopUpInFourCrossPaint)
				dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("一望無際的沙漠景象"),
				dialogHolder.TalkDialog ("有點乾燥的風迎面而來"),
			};
			else
				dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog (".........."),
				dialogHolder.AskDialog ("回去", "待著", new List<Dialog> {
					dialogHolder.TalkDialog ("再調查一下好了")
				}), dialogHolder.TalkDialog ("..................")
			};
		}
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (SceneManager.GetActiveScene ().buildIndex == 6) {
			if (dialogHolder.AskDialogAnswerList [0] == 1)
				sceneLoader.LoadSceneAndMovePlayer (7, new Vector3 (-15, player.transform.position.y, 0), 1);				
		} else {
			if (!hasDialogPopUpInFourCrossPaint)
				hasDialogPopUpInFourCrossPaint = true;
			else if (dialogHolder.AskDialogAnswerList [0] == 1)
				sceneLoader.LoadSceneAndMovePlayer (6, new Vector3 (14, player.transform.position.y, 0), -1);
		}
	}
}
