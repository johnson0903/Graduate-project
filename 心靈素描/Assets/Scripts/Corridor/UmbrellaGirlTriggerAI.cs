using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class UmbrellaGirlTriggerAI : MonoBehaviour {

	public GameObject umbrellaGirl;
	public GameObject umBrellaGirlPaint_Left;
	public GameObject umBrellaGirlPaint_Right;
	public Sprite umbrellaGirlWithBlood_Left;
	public Sprite umbrellaGirlWithBlood_Right;
	public Sprite black;

	private DialogHolder dialogHolder;

	private static bool isShockedInCorridor;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;
	}

	public void MissionComplete()
	{
		dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("........??")
		};
		dialogHolder.IsAutoPopUp = true;
	}


	void OnDialogOver (object sender, EventArgs e)
	{
		umbrellaGirl.GetComponent<UmbrellaGirlAI> ().Move ();
		dialogHolder.Dialogs = null;
	}

}
