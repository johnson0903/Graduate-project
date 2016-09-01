using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BalancePaint_LeftAI : MonoBehaviour {

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

		dialogHolder.Dialogs = new List<Dialog> { dialogHolder.TalkDialog ("一幅左右平衡天秤的畫"),
			dialogHolder.TalkDialog ("兩側的空盤暗示著什麼？")
		};

	}

	void OnDialogOver(object sender, EventArgs e)
	{	

	}
}
