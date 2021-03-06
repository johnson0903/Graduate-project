﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bedroom_PillowAI : MonoBehaviour {

	public GameObject Bedroomkey;
	public Sprite brokenPillowImage;

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isPillowKeyTaken;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
		this.GetComponent<DialogHolder> ().EventDialogEvent += OnEventDialogOccur;
		if (isPillowKeyTaken)
			this.GetComponent<SpriteRenderer> ().sprite = brokenPillowImage;
	}

	// Update is called once per frame
	void Update()
	{
		//如果枕頭裡的鑰匙還沒被拿走
		if (!isPillowKeyTaken) {
			if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BoxCutter")) {     //如果身上有美工刀
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("軟綿綿的枕頭"),
					dialogHolder.TalkDialog ("感覺躺起來很舒服"),
					dialogHolder.AskDialog ("用美工刀劃開枕頭", "躺躺看", new List<Dialog> {
						dialogHolder.TalkDialog ("......"),
						dialogHolder.TalkDialog ("貪睡鬼")
					}),
					dialogHolder.EventDialog ("嘶嘶嘶嘶....", false, 0 , .5f),
					dialogHolder.PickUpItemDialog ("獲得了 臥室的鑰匙", Bedroomkey)
				};
			} else    //如果身上沒有美工刀
				dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("軟綿綿的枕頭"),
					dialogHolder.TalkDialog ("感覺躺起來很舒服"),
					dialogHolder.AskDialog ("摸摸看", "躺躺看", new List<Dialog> {
						dialogHolder.TalkDialog ("......"),
						dialogHolder.TalkDialog ("貪睡鬼"),
					}),
					dialogHolder.TalkDialog ("軟綿綿的"),
					dialogHolder.TalkDialog ("但是好像有個硬硬的東西")
				};
		} else    //枕頭的鑰匙被拿了
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("破了洞的枕頭靜靜地躺在床上"),
			dialogHolder.TalkDialog ("破口周圍滲出了奇怪的液體...")
			};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (!isPillowKeyTaken && player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("BoxCutter") && dialogHolder.AskDialogAnswerList[0] == 1)
			isPillowKeyTaken = true;
	}

	void OnEventDialogOccur(object sender, EventArgs e)
	{	
		this.GetComponent<SpriteRenderer> ().sprite = brokenPillowImage;
	}
}
