using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bathroom_SinkAI : MonoBehaviour {

	public GameObject waterBottle;

	private const int WATER_SFX = 0;
	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController>().gameObject;
		dialogHolder = this.GetComponent<DialogHolder>();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("Bottle")) {  
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 擦得發亮的洗手台"),
				dialogHolder.TalkDialog ("水龍頭有水可以用的樣子"),
				dialogHolder.AskDialog ("將空瓶裝滿水", "不理他", new List<Dialog> {
					dialogHolder.TalkDialog ("調查其他地方吧")
				}),
				dialogHolder.PlaySoundDialog ("啾嚕嚕嚕嚕....", WATER_SFX),
				dialogHolder.PickUpItemDialog ("獲得了 裝著水的瓶子", waterBottle)
			};
		} else
			dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 擦得發亮的洗手台"),
				dialogHolder.TalkDialog ("水龍頭有水可以用的樣子"),
			};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (player.GetComponent<PlayerInventory> ().IsSomethingInInventory ("Bottle") && dialogHolder.AskDialogAnswerList [0] == 1)
			player.GetComponent<PlayerInventory> ().DropItem ("Bottle");
	}
}
