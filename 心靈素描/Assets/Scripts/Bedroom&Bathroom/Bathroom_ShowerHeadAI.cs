using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Bathroom_ShowerHeadAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("用來淋浴用的蓮蓬頭"),
			dialogHolder.TalkDialog ("現在打開的話會淋濕身體的吧"),
			dialogHolder.TalkDialog ("不要亂動好了")
		};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	

	}
}
