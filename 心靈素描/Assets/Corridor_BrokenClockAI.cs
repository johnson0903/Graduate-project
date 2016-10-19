using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Corridor_BrokenClockAI : MonoBehaviour {

	public GameObject pointer; 

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isPointerTaken;

	// Use this for initialization
	void Start()
	{
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	// Update is called once per frame
	void Update()
	{
		if (!isPointerTaken) {
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("這個是.... 剛剛門上的時鐘嗎？"),
				dialogHolder.TalkDialog ("看上去好像壞掉了 指針那邊好像怪怪的"),
				dialogHolder.AskDialog ("調查看看指針", "將指針拆下來", new List<Dialog> {
					dialogHolder.TalkDialog ("......"),
					dialogHolder.TalkDialog ("......掉下來了"),
					dialogHolder.TalkDialog ("擦拭乾淨之後 發現還滿漂亮的"),
					dialogHolder.PickUpItemDialog ("獲得了 指針", pointer)
				}),
				dialogHolder.TalkDialog ("......怎麼轉都轉不回去"),
				dialogHolder.TalkDialog ("不小心把時針轉掉了"),
				dialogHolder.TalkDialog ("將指針擦拭乾淨之後 發現還滿漂亮的"),
				dialogHolder.PickUpItemDialog ("獲得了 指針", pointer)
			};
		}
		else 
			dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("壞掉的時鐘靜靜地靠在牆上"),
			dialogHolder.TalkDialog ("時針已經完全不會動了...")
		};
	}



	void OnDialogOver(object sender, EventArgs e)
	{	
		if (!isPointerTaken) {
			Destroy (transform.FindChild ("Hour").gameObject);
			isPointerTaken = true;
		}
	}
}
