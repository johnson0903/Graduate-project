﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class FourCrossPaint_DoorAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool hasDialogPopUpInFourCrossPaint;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		player.transform.position = new Vector3 (this.transform.position.x, player.transform.position.y, player.transform.position.z);

		if(!hasDialogPopUpInFourCrossPaint)
			dialogHolder.IsAutoPopUp = true;
	}

	// Update is called once per frame
	void Update () {

		if (!hasDialogPopUpInFourCrossPaint)
			dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("乾燥的風迎面而來"),
			dialogHolder.TalkDialog ("吹的皮膚不太舒服..."),
		};
		else
			dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog (".........."),
			dialogHolder.AskDialog ("回去", "待著", new List<Dialog> {
				dialogHolder.TalkDialog ("再調查一下好了")
			}), dialogHolder.TalkDialog ("..................")
		};
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		if (!hasDialogPopUpInFourCrossPaint)
			hasDialogPopUpInFourCrossPaint = true;
		else if (dialogHolder.AskDialogAnswerList [0] == 1) {
			player.GetComponent<PlayerController> ().MoveToOriginPositionX ();
			SceneManager.LoadScene (0);
		}
	}
}
