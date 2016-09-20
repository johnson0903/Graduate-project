using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ParentsDoorAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("門鎖的相當緊")
		};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	

	}
}
