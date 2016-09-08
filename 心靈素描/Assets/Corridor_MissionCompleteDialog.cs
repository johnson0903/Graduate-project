using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Corridor_MissionCompleteDialog : MonoBehaviour {

	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
	}

	public void MissionComplete()
	{
		dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("........??"),
			dialogHolder.TalkDialog ("走廊的異樣感消失了")
		};
		dialogHolder.IsAutoPopUp = true;
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		dialogHolder.Dialogs = null;
	}
}
