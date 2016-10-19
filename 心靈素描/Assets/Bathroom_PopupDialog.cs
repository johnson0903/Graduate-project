using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Bathroom_PopupDialog : MonoBehaviour {

	private DialogHolder dialogHolder;

	private static bool hasDialogPopUpInBathroom;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if(SceneManager.GetActiveScene ().buildIndex == 2 && !hasDialogPopUpInBathroom)
			dialogHolder.IsAutoPopUp = true;
	}

	// Use this for initialization
	void Update () {
		if (!hasDialogPopUpInBathroom)
			dialogHolder.Dialogs = new List<Dialog> {
			dialogHolder.TalkDialog ("裝飾地相當華麗的廁所"),
			dialogHolder.TalkDialog ("但不知為什麼 有種怪異的感覺...")
		};
		else
			dialogHolder.Dialogs = null;
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		hasDialogPopUpInBathroom = true;
	}
}
