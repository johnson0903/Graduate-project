using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FourCrossPaint_MissionCompleteDialog : MonoBehaviour {

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
			dialogHolder.TalkDialog ("喀擦"),
			dialogHolder.TalkDialog ("從哪裡傳來了箱子打開的聲音")
		};
		dialogHolder.IsAutoPopUp = true;
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		
	}

}