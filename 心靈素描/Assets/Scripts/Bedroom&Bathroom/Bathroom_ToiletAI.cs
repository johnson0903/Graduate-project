using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bathroom_ToiletAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用陶瓷做的 純白色的馬桶"),
			dialogHolder.TalkDialog ("馬桶蓋子是蓋上的"),
			dialogHolder.AskDialog ("將蓋子打開", "不理他", new List<Dialog> {
				dialogHolder.TalkDialog ("調查其他地方吧")
			}),
			dialogHolder.TalkDialog ("嘎拉－"),
			dialogHolder.TalkDialog ("..........！？")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}
}
