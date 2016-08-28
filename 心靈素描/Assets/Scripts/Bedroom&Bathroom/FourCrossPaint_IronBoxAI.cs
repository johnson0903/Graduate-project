using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FourCrossPaint_IronBoxAI : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;
	private static bool isFourCrossPuzzleCompleted;
	private static bool isTreasureTaken;

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
		if (!isFourCrossPuzzleCompleted) {
			dialogHolder.Dialogs = new List<Dialog> { 
				dialogHolder.TalkDialog ("用堅固的鋼鐵所做成的箱子"),
				dialogHolder.TalkDialog ("上面的蓋子關得緊緊的...")
			};

		} else if (!isTreasureTaken)
			dialogHolder.Dialogs = new List<Dialog> { 
				dialogHolder.TalkDialog ("蓋子的卡榫被打開了"),
				dialogHolder.TalkDialog ("你得到他了")
			};
		else
			dialogHolder.Dialogs = new List<Dialog> { 
				dialogHolder.TalkDialog ("鐵箱子裡面空空的"),
				dialogHolder.TalkDialog ("已經沒有其他東西了")
			};
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		if (isFourCrossPuzzleCompleted)
			isTreasureTaken = true;
	}

	public void MissionComplete()
	{	
		isFourCrossPuzzleCompleted = true;
	}
}
