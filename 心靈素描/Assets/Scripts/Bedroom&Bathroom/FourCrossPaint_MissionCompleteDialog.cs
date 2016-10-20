using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FourCrossPaint_MissionCompleteDialog : MonoBehaviour {

	public GameObject happyCross;
	public GameObject oldBackGround;
	public Sprite newBackGroundImage;

	private GameObject player;
	private DialogHolder dialogHolder;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().gameObject;
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder>().DialogOverEvent += OnDialogOver;
		this.GetComponent<DialogHolder> ().EventDialogEvent += OnEventDialogOccur;
	}

	public void MissionComplete()
	{
		dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.EventDialog ("趴擦", false, 0, 0.5f),
			dialogHolder.TalkDialog ("發出了一聲巨大的聲響")
		};
		dialogHolder.IsAutoPopUp = true;
	}

	void OnDialogOver(object sender, EventArgs e)
	{	
		dialogHolder.Dialogs = null;
	}

	void OnEventDialogOccur(object sender, EventArgs e)
	{	
		Destroy (happyCross.transform.GetChild (1).gameObject);
		oldBackGround.GetComponent<SpriteRenderer> ().sprite = newBackGroundImage;
	}


}