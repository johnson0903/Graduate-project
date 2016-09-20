using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MomPaintAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("牆上掛著一幅女性的畫像"),
			dialogHolder.TalkDialog ("裡面的人笑得相當詭異...")
		};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}
}
