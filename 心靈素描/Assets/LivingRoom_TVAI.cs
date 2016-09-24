using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class LivingRoom_TVAI : MonoBehaviour {

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
		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("電視的螢幕上面閃爍著紅色的畫面"),
			dialogHolder.TalkDialog ("按電源鍵也沒有任何反應...")
		};
	}


	void OnDialogOver(object sender, EventArgs e)
	{	

	}
}
