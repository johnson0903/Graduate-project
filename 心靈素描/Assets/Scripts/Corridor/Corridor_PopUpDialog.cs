using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Collections.Generic;

public class Corridor_PopUpDialog : MonoBehaviour {

	private DialogHolder dialogHolder;

	private static bool hasDialogPopUpInCorridor;

	// Use this for initialization
	void Start () {
		dialogHolder = this.GetComponent<DialogHolder> ();
		this.GetComponent<DialogHolder> ().DialogOverEvent += OnDialogOver;

		if (SceneManager.GetActiveScene ().buildIndex == 4 && !hasDialogPopUpInCorridor)
			dialogHolder.IsAutoPopUp = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasDialogPopUpInCorridor)
			dialogHolder.Dialogs = new List<Dialog> {
				dialogHolder.TalkDialog ("........."),
				dialogHolder.TalkDialog ("有一種令人不舒服的感覺..."),
			};
		else
			dialogHolder.Dialogs = null;
	}

	void OnDialogOver (object sender, EventArgs e)
	{
		hasDialogPopUpInCorridor = true;
	}
		
}
