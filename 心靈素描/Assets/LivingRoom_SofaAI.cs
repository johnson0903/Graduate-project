using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_SofaAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("看起來軟綿綿的沙發"),
			dialogHolder.TalkDialog ("坐在上面會相當舒服的樣子")
		};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	

	}
}
